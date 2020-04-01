using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Serilog;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class PredictionTrainerService : IPredictionTrainerService
    {
        private readonly IRatingCursoRepository ratingCursoRepository;
        private readonly ICursoRepository cursoRepository;
        private readonly IParticipanteRepository participanteRepository;
        private readonly IPredictionTrainerRepository predictionTrainerRepository;
        public PredictionTrainerService(IRatingCursoRepository ratingCursoRepository, ICursoRepository cursoRepository, IParticipanteRepository participanteRepository, 
            IPredictionTrainerRepository predictionTrainerRepository, IConfiguration config)
        {
            this.ratingCursoRepository = ratingCursoRepository;
            this.cursoRepository = cursoRepository;
            this.participanteRepository = participanteRepository;
            this.predictionTrainerRepository = predictionTrainerRepository;
            var seqUrl = config.GetSection("AppSettings:SeqUrl").Value.ToString();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Seq(seqUrl)
                .CreateLogger();
        }
        public async Task<bool> CreatePredictionCoursesForParticipants()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Log.Information("Inicio CreatePredictionCoursesForParticipants");
            try
            { 
                var ratingCursos = await ratingCursoRepository.GetAllAsync();

                var ratingCursosToTrain = ratingCursos.Select(x => new CourseEntry { IdCurso = Convert.ToUInt32(x.IdCurso), IdParticipante = Convert.ToUInt32(x.IdParticipante), Rating = (float)x.Rating }).ToList();

                MLContext mlContext = new MLContext();

                var traindata = mlContext.Data.LoadFromEnumerable(ratingCursosToTrain);

                MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                options.MatrixColumnIndexColumnName = nameof(CourseEntry.IdCurso);
                options.MatrixRowIndexColumnName = nameof(CourseEntry.IdParticipante);
                options.LabelColumnName = "Rating";
                options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossRegression;
                options.Alpha = 0.01;
                options.Lambda = 0.025;
                options.NumberOfIterations = 1000;

                var trainingPipeLine = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                ITransformer model = trainingPipeLine.Fit(traindata);

                var predictionengine = mlContext.Model.CreatePredictionEngine<CourseEntry, CursoRatingPrediction>(model);

                int? allItemsInteger = default;
                var cursos = await cursoRepository.GetCursosAsync(allItemsInteger, allItemsInteger, allItemsInteger, default);
                var participantes = await participanteRepository.GetParticipantesAsync(allItemsInteger, allItemsInteger);
                await predictionTrainerRepository.ClearPredictionsAsync();
                Log.Information("All predictions has deleted until {date}", DateTime.Now);
                foreach (var participante in participantes)
                {
                    var topCursos = cursos.Select(x => new
                    {
                        Curso = x.Nombre,
                        x.IdCurso,
                        Score = (predictionengine.Predict(
                                    new CourseEntry()
                                    {
                                        IdCurso = Convert.ToUInt16(x.IdCurso),
                                        IdParticipante = Convert.ToUInt16(participante.IdParticipante)
                                    }).Score)
                    }).OrderByDescending(x => x.Score).Take(5);
                    foreach (var item in topCursos)
                    {
                        Console.WriteLine($" Participante: {participante.IdParticipante}  {participante.Nombre} Curso: {item.Curso} prediction.Rating: {Math.Round(item.Score)}  {item.Score} ");
                        RatingCursoEntity ratingCursoEntity = new RatingCursoEntity();
                        var rating = (int)Math.Round(item.Score);
                        ratingCursoEntity.Rating = rating >= (int)decimal.Zero ? rating : (int)decimal.Zero;
                        ratingCursoEntity.IdParticipante = participante.IdParticipante;
                        ratingCursoEntity.IdCurso = item.IdCurso;
                        await predictionTrainerRepository.CreatePredictionCourseForParticipantAsync(ratingCursoEntity);
                    }
                }
                stopWatch.Stop();
                Log.Information("Finalizado CreatePredictionCoursesForParticipants in {elapsedTime}", stopWatch.Elapsed);
                return true;
            }
            catch (Exception ex)
            {
                stopWatch.Stop();
                Log.Error("Un error a ocurrido en la Predicción de Cursos con la siguiente excepción: {errormessage}", ex.Message);
                return false;
            }    
        }

    }

    public class CursoRatingPrediction
    {
        public float Score { get; set; }
    }

    public class CourseEntry
    {
        [KeyType(count: 262111)]
        public uint IdCurso { get; set; }

        [KeyType(count: 262111)]
        public uint IdParticipante { get; set; }

        public float Rating { get; set; }
    }
}

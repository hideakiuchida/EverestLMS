using EverestLMS.Common.Connections;
using EverestLMS.Repository.DapperImplementations;
using EverestLMS.Repository.Interfaces;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EverestLMS.MLPredictionTrainer
{
    class Program
    {
        static string connectionString = ConnectionSettings.ConnectionString;
        static IRatingCursoRepository ratingCursoRepository;
        static ICursoRepository cursoRepository;
        static IParticipanteRepository participanteRepository;
        public class CursoRatingPrediction
        {
            public float Score;
        }

        public class CourseEntry
        {
            [KeyType(count: 262111)]
            public uint IdCurso { get; set; }

            [KeyType(count: 262111)]
            public uint IdParticipante { get; set; }

            public float Rating { get; set; }
        }

        static void Main(string[] args)
        {
            IDbConnection connection = new SqlConnection(connectionString);
            ratingCursoRepository = new RatingCursoRepository(connection, default);
            cursoRepository = new CursoRepository(connection, default);
            participanteRepository = new ParticipanteRepository(connection, default);

            var ratingCursos = ratingCursoRepository.GetAllAsync().Result;

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
            var cursos = cursoRepository.GetCursosAsync(allItemsInteger, allItemsInteger, allItemsInteger, default).Result;
            var participantes = participanteRepository.GetParticipantesAsync(allItemsInteger, allItemsInteger).Result;
            foreach (var participante in participantes)
            {
                var topCursos = cursos.ToList().Select(x => new
                {
                    Curso = x.Nombre,
                    Score = (predictionengine.Predict(
                                new CourseEntry()
                                {
                                    IdCurso = Convert.ToUInt32(x.IdCurso),
                                    IdParticipante = Convert.ToUInt32(participante.IdParticipante)
                                }).Score)
                }).OrderByDescending(x => x.Score).Take(5);
                foreach (var item in topCursos)
                {
                    Console.WriteLine($" Participante: {participante.IdParticipante}  {participante.Nombre} Curso: {item.Curso} prediction.Rating: {Math.Round(item.Score)}  {item.Score} ");
                }
            }
   
            Console.ReadLine();
        }
    }
}

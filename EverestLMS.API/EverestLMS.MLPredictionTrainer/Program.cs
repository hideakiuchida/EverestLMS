using EverestLMS.Common.Connections;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.DapperImplementations;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EverestLMS.MLPredictionTrainer
{
    class Program
    {
        static string connectionString = ConnectionSettings.ConnectionString;
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
            Console.WriteLine("Start Training ML");
            IDbConnection connection = new SqlConnection(connectionString);
            var ratingCursoRepository = new RatingCursoRepository(connection);
            var cursoRepository = new CursoRepository(connection);
            var participanteRepository = new ParticipanteRepository(connection);

            try
            {
                int? allItemsInteger = default;
                var cursos = cursoRepository.GetCursosAsync(allItemsInteger, allItemsInteger, allItemsInteger, default).Result;
                var participantes = participanteRepository.GetParticipantesAsync(allItemsInteger, allItemsInteger).Result;
                var ratingCursos = ratingCursoRepository.GetAllAsync().Result;
                MatrixFactorizationTrainModel(ratingCursos, cursos, participantes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            Console.WriteLine("End Training ML");
        }

        private static void MatrixFactorizationTrainModel(IEnumerable<RatingCursoEntity> ratingCursos, IEnumerable<CursoDetalleEntity> cursos, IEnumerable<ParticipanteEntity> participantes)
        {
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

            foreach (var participante in participantes)
            {
                var topCursos = cursos.Select(x => new
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

using EverestLMS.Entities.Models;
using EverestLMS.Repository.DapperImplementations;
using EverestLMS.Repository.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.GeneradorCursoRating
{
    public class Program
    {
        static long count = 0;
        static string connectionString = "Server=HIDEAKIUCHIDA;Database=EVERESTLMS;Integrated Security=True;";
        static IParticipanteRepository participanteRepository;
        static ICursoRepository cursoRepository;
        static INivelRepository nivelRepository;
        static ILineaCarreraRepository lineaCarreraRepository;
        static IRatingCursoRepository ratingCursoRepository;

        public static void Main(string[] args)
        {
            Console.WriteLine("Comenzó Generador Curso Rating!");
            IDbConnection connection = new SqlConnection(connectionString);
            nivelRepository = new NivelRepository(connection, default);
            lineaCarreraRepository = new LineaCarreraRepository(connection, default);
            
            cursoRepository = new CursoRepository(connection, default);

            participanteRepository = new ParticipanteRepository(connection, default);
            ratingCursoRepository = new RatingCursoRepository(connection, default);
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    GenerarRatingCursosAleatorios();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción: " + ex.Message);
            }
            Console.WriteLine("Finalizó Generador Curso Rating!");
            Console.ReadLine();
        }

        static void GenerarRatingCursosAleatorios()
        {
            var niveles = nivelRepository.GetAllAsync().Result;
            var lineas = lineaCarreraRepository.GetAllAsync().Result;

            foreach (var linea in lineas)
            {
                foreach (var nivel in niveles)
                {
                    var cursos = cursoRepository.GetCursosAsync(default, linea.IdLineaCarrera, nivel.IdNivel, default).Result;
                    var participantes = participanteRepository.GetParticipantesAsync(linea.IdLineaCarrera, nivel.IdNivel).Result;

                    if (cursos == null || cursos.ToList().Count == default(int))
                        continue;
                    if (participantes == null || participantes.ToList().Count == default(int))
                        continue;

                    foreach (var participante in participantes)
                    {
                        foreach (var curso in cursos)
                        {
                            RatingCursoEntity ratingCursoEntity = new RatingCursoEntity();
                            ratingCursoEntity.IdCurso = curso.IdCurso;
                            ratingCursoEntity.IdParticipante = participante.IdParticipante;
                            Random random = new Random();
                            var ratingCurso = random.Next(1, 6);
                            ratingCursoEntity.Rating = ratingCurso;
                            if (ratingCursoEntity != null)
                            {
                                ratingCursoRepository.CreateAsync(ratingCursoEntity);
                                count++;
                                Console.WriteLine($"{count} RatingCursoEntity: {curso.Nombre} {participante.Nombre} {ratingCurso}");
                            }                          
                        }
                    }
                }
            }
            
        }
    }
}

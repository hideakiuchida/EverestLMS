using AutoMapper;
using EverestLMS.API.Helpers;
using EverestLMS.Common.Connections;
using EverestLMS.Common.Fakes;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.DapperImplementations;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Implementations;
using EverestLMS.Services.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.PopulateData
{
    public class Program
    {
        static long count = 0;
        static string connectionString = ConnectionSettings.ConnectionString;
        static IDbConnection connection;
        static IParticipanteRepository participanteRepository;
        static ICursoRepository cursoRepository;
        static INivelRepository nivelRepository;
        static ILineaCarreraRepository lineaCarreraRepository;
        static IRatingCursoRepository ratingCursoRepository;
        static IConocimientoRepository conocimientoRepository;

        static IParticipanteService _service;
        private static ParticipanteFaker _faker;

        public async static Task Main(string[] args)
        {
            Console.WriteLine("Comenzó Generador de Data!");
            connection = new SqlConnection(connectionString);
            nivelRepository = new NivelRepository(connection, default);
            lineaCarreraRepository = new LineaCarreraRepository(connection, default);
            conocimientoRepository = new ConocimientoRepository(connection, default);
            participanteRepository = new ParticipanteRepository(connection, default);
            ratingCursoRepository = new RatingCursoRepository(connection, default);
            cursoRepository = new CursoRepository(connection, default);

            var myProfile = new AutoMapperProfiles();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            _service = new ParticipanteService(participanteRepository, conocimientoRepository, mapper, null);
            
            try
            {
                _faker = new ParticipanteFaker();

                await GenerarEscaladores();
                await GenerarSherpas();
                await GenerarCursoImagenes();
                for (int i = 0; i < 3; i++)
                    GenerarRatingCursosAleatorios();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción: " + ex.Message);
            }
            Console.WriteLine("Finalizó Generador Data!");
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

        static async Task GenerarSherpas()
        {
            Console.WriteLine("Generar Sherpas");
            foreach (var item in _faker.GetSherpasVM())
            {
                var result = await _service.CreateAsync(item);
                Console.WriteLine("Successfully created: " + result);
            }
            Console.WriteLine("Finalizar Sherpas");
        }

        static async Task GenerarEscaladores()
        {
            Console.WriteLine("Generar Escaladores");
            foreach (var item in _faker.GetEscaladoresVM())
            {
                var result = await _service.CreateAsync(item);
                Console.WriteLine("Successfully created: " + result);
            }
            Console.WriteLine("Finalizar Escaladores");
        }
        static async Task GenerarCursoImagenes()
        {
            Console.WriteLine("Generar Curso Imagenes");
            ICursoRepository cursoRepository = new CursoRepository(connection, default);
            var cursos = await cursoRepository.GetCursosAsync(default, default, default, default);
            ICloudinaryFileRepository cloudinaryFileRepository = new CloudinaryFileRepository(connection, default);
            foreach (var item in cursos)
            {
                var cloudinaryFileEntity = new CloudinaryFileEntity();
                cloudinaryFileEntity.IdCurso = item.IdCurso;
                cloudinaryFileEntity.Url = "https://res.cloudinary.com/ddqwjtgb5/image/upload/v1569787481/g3qe4rtm6chpztruamoh.jpg";
                var result = await cloudinaryFileRepository.CreateCloudinaryFileAsync(cloudinaryFileEntity);
                Console.WriteLine("Successfully created: " + result);
            }
            Console.WriteLine("Finalizar Curso Imagenes");
        }

    }
}

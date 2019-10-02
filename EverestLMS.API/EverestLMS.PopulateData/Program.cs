using AutoMapper;
using EverestLMS.API.Helpers;
using EverestLMS.Common.Fakes;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.DapperImplementations;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Implementations;
using EverestLMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EverestLMS.PopulateData
{
    class Program
    {
        /// <summary>
        /// The system under test
        /// </summary>
        private static IParticipanteService _service;

        private static ParticipanteFaker _faker;

        private static SqlConnection _sqlConnection;
        static void Main(string[] args)
        {
            _ = PopulateData();
        }

        private async static Task PopulateData()
        {
            try
            {
                _faker = new ParticipanteFaker();

                string connectionString = "Server=HIDEAKIUCHIDA;Database=EVERESTLMS;Integrated Security=True;";
                _sqlConnection = new SqlConnection(connectionString);
                IParticipanteRepository participanteRepository = new ParticipanteRepository(_sqlConnection, default);
                IConocimientoRepository conocimientoRepository = new ConocimientoRepository(_sqlConnection, default);
                var myProfile = new AutoMapperProfiles();
                var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
                var mapper = new Mapper(configuration);
                _service = new ParticipanteService(participanteRepository, conocimientoRepository, mapper, null);

                await SeedSherpas();
                await SeedEscaladores();

                ICursoRepository cursoRepository = new CursoRepository(_sqlConnection, default);
                var cursos = await cursoRepository.GetCursosAsync(default, default, default, default);

                await SeedCursoImagenes(cursos);
                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Excepction: " + exception.Message);
            }
           
        }

        private static async Task SeedSherpas()
        {
            foreach (var item in _faker.GetSherpasVM())
            {
                var result = await _service.CreateAsync(item);
                Console.WriteLine("Successfully created: " + result);
            }
        }
        private static async Task SeedEscaladores()
        {
            foreach (var item in _faker.GetEscaladoresVM())
            {
                var result = await _service.CreateAsync(item);
                Console.WriteLine("Successfully created: " + result);
            }
        }

        private static async Task SeedCursoImagenes(IEnumerable<CursoDetalleEntity> cursos)
        {
            ICloudinaryFileRepository cloudinaryFileRepository = new CloudinaryFileRepository(_sqlConnection, default);
            foreach (var item in cursos)
            {
                var cloudinaryFileEntity = new CloudinaryFileEntity();
                cloudinaryFileEntity.IdCurso = item.IdCurso;
                cloudinaryFileEntity.Url = "https://res.cloudinary.com/ddqwjtgb5/image/upload/v1569787481/g3qe4rtm6chpztruamoh.jpg";
                var result = await cloudinaryFileRepository.CreateCloudinaryFileAsync(cloudinaryFileEntity);
                Console.WriteLine("Successfully created: " + result);
            }
        }
    }
}

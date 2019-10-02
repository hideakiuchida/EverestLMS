using AutoMapper;
using EverestLMS.API.Helpers;
using EverestLMS.Common.Fakes;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.DapperImplementations;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Implementations;
using EverestLMS.Services.Interfaces;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EverestLMS.IntegrationTests
{
    public class SeedDataIntegrationTest
    {
        /// <summary>
        /// The system under test
        /// </summary>
        private IParticipanteService _service;

        private ParticipanteFaker _faker;

        private SqlConnection _sqlConnection;

        [SetUp]
        public void Init()
        {
            _faker = new ParticipanteFaker();
    
            string connectionString= "Server=HIDEAKIUCHIDA;Database=EVERESTLMS;Integrated Security=True;";
            _sqlConnection = new SqlConnection(connectionString);
            IParticipanteRepository participanteRepository = new ParticipanteRepository(_sqlConnection, default);
            IConocimientoRepository conocimientoRepository = new ConocimientoRepository(_sqlConnection, default);
            var myProfile = new AutoMapperProfiles();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            _service = new ParticipanteService(participanteRepository, conocimientoRepository, mapper, null);
        }

        [Test]
        public async Task SeedSherpas()
        {
            foreach (var item in _faker.GetSherpasVM())
            {
                var result = await _service.CreateAsync(item);
                Assert.IsTrue(result > 0);
            }  
        }

        [Test]
        public async Task SeedEscaladores()
        {
            foreach (var item in _faker.GetEscaladoresVM())
            {
                var result = await _service.CreateAsync(item);
                Assert.IsTrue(result > 0);
            }
        }

        [Test]
        public async Task SeedCursoImagenes()
        {
            ICursoRepository cursoRepository = new CursoRepository(_sqlConnection, default);
            var cursos = await cursoRepository.GetCursosAsync(default, default, default, default);
            ICloudinaryFileRepository cloudinaryFileRepository = new CloudinaryFileRepository(_sqlConnection, default);
            foreach (var item in cursos)
            {
                var cloudinaryFileEntity = new CloudinaryFileEntity();
                cloudinaryFileEntity.IdCurso = item.IdCurso;
                cloudinaryFileEntity.Url = "https://res.cloudinary.com/ddqwjtgb5/image/upload/v1569787481/g3qe4rtm6chpztruamoh.jpg";
                var result = await cloudinaryFileRepository.CreateCloudinaryFileAsync(cloudinaryFileEntity);
                Assert.IsTrue(result > 0);
            }
        }
    }
}

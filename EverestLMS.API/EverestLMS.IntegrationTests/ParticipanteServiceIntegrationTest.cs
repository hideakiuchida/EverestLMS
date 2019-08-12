using AutoMapper;
using EverestLMS.API.Helpers;
using EverestLMS.Common.Fakes;
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
    public class ParticipanteServiceIntegrationTest
    {
        /// <summary>
        /// The system under test
        /// </summary>
        private IParticipanteService _service;

        private ParticipanteFaker _faker;

        [SetUp]
        public void Init()
        {
            _faker = new ParticipanteFaker();
    
            string connectionString= "Server=HIDEAKIUCHIDA;Database=EVERESTLMS;Integrated Security=True;";
            IParticipanteRepository participanteRepository = new ParticipanteRepository(new SqlConnection(connectionString), default);
            IConocimientoRepository conocimientoRepository = new ConocimientoRepository(new SqlConnection(connectionString), default);
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
    }
}

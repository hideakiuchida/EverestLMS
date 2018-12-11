using AutoMapper;
using EverestLMS.API.Helpers;
using EverestLMS.Common.Fakes;
using EverestLMS.DataAccess;
using EverestLMS.Repository.ConocimientoRepository;
using EverestLMS.Repository.Participante;
using EverestLMS.Services.Participante;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
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
            var builder = new DbContextOptionsBuilder<everestlmsContext>();
            builder.UseMySQL("server=localhost;port=3306;database=EverestLMS;uid=root;password=mysql");
            everestlmsContext everestlmsContext = new everestlmsContext(builder.Options);
            IParticipanteRepository participanteRepository = new ParticipanteRepository(everestlmsContext);
            IConocimientoRepository conocimientoRepository = new ConocimientoRepository(everestlmsContext);
            var myProfile = new AutoMapperProfiles();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            _service = new ParticipanteService(participanteRepository, conocimientoRepository, mapper);
        }

        [Test]
        public async Task SeedSherpas()
        {
            foreach (var item in _faker.GetSherpasVM())
            {
                var result = await _service.CreateAsync(item);
                Assert.IsTrue(result.Id > 0);
            }  
        }

        [Test]
        public async Task SeedEscaladores()
        {
            foreach (var item in _faker.GetEscaladoresVM())
            {
                var result = await _service.CreateAsync(item);
                Assert.IsTrue(result.Id > 0);
            }
        }
    }
}

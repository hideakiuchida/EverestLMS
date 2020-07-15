using Bogus;
using EverestLMS.Common.Enums;
using EverestLMS.ViewModels.Authentication;
using EverestLMS.ViewModels.Participante;
using System;
using System.Collections.Generic;

namespace EverestLMS.Common.Fakes
{
    public class ParticipanteFaker
    {
        private UsuarioToRegisterVM SherpaToCreateVM;
        public UsuarioToRegisterVM GetSherpaToCreateVM()
        {
            if (SherpaToCreateVM == null)
            {
                var Participante = new Faker<ParticipanteToCreateVM>()
                    .RuleFor(g => g.Nombre, f => f.Name.FirstName())
                    .RuleFor(g => g.Apellido, f => f.Name.LastName())
                    .RuleFor(g => g.Correo, f => f.Person.Email)
                    .RuleFor(g => g.Genero, f => f.PickRandom((int)GeneroEnum.Masculino, (int)GeneroEnum.Femenino))
                    .RuleFor(g => g.AñosExperiencia, f => f.Random.Number(1, 10))
                    .RuleFor(g => g.Calificacion, f => f.Random.Number(1, 20))
                    .RuleFor(g => g.FechaNacimiento, f => f.Date.Past())
                    .RuleFor(g => g.IdLineaCarrera, f => f.PickRandom((int)LineaCarreraEnum.BusinessAnalyst, (int)LineaCarreraEnum.SoftwareEngineer, (int)LineaCarreraEnum.DevOpsEngineer,
                        (int)LineaCarreraEnum.MobileEngineer, (int)LineaCarreraEnum.QualityAssurance))
                    .RuleFor(g => g.IdNivel, f => (int)NivelEnum.Senior);
                SherpaToCreateVM = new Faker<UsuarioToRegisterVM>()
                    .RuleFor(g => g.Username, f => f.Person.UserName)
                    .RuleFor(g => g.Password, f => "12345")
                    .RuleFor(g => g.IdRol, f => (int)RolEnum.Sherpa)
                    .RuleFor(g => g.Participante, f => Participante);
                
            }
            return SherpaToCreateVM;
        }

        private UsuarioToRegisterVM EscaladorToCreateVM;
        public UsuarioToRegisterVM GetEscaladorToCreateVM()
        {
            if (EscaladorToCreateVM == null)
            {
                var Participante = new Faker<ParticipanteToCreateVM>()
                    .RuleFor(g => g.Nombre, f => f.Name.FirstName())
                    .RuleFor(g => g.Apellido, f => f.Name.LastName())
                    .RuleFor(g => g.Correo, f => f.Person.Email)
                    .RuleFor(g => g.Genero, f => f.PickRandom((int)GeneroEnum.Masculino, (int)GeneroEnum.Femenino))
                    .RuleFor(g => g.AñosExperiencia, f => f.Random.Number(1, 10))
                    .RuleFor(g => g.Calificacion, f => f.Random.Number(1, 20))
                    .RuleFor(g => g.FechaNacimiento, f => f.Date.Past())
                    .RuleFor(g => g.IdLineaCarrera, f => f.PickRandom((int)LineaCarreraEnum.BusinessAnalyst, (int)LineaCarreraEnum.SoftwareEngineer, (int)LineaCarreraEnum.DevOpsEngineer,
                        (int)LineaCarreraEnum.MobileEngineer, (int)LineaCarreraEnum.QualityAssurance))
                    .RuleFor(g => g.IdNivel, f => (int)NivelEnum.Senior);
                EscaladorToCreateVM = new Faker<UsuarioToRegisterVM>()
                    .RuleFor(g => g.Username, f => f.Person.UserName)
                    .RuleFor(g => g.Password, f => "12345")
                    .RuleFor(g => g.IdRol, f => (int)RolEnum.Escalador)
                    .RuleFor(g => g.Participante, f => Participante);
            }
            return EscaladorToCreateVM;
        }

        private IList<UsuarioToRegisterVM> SherpasVM;
        public IList<UsuarioToRegisterVM> GetSherpasVM()
        {
            if (SherpasVM == null)
            {
                var Participante = new Faker<ParticipanteToCreateVM>()
                    .RuleFor(g => g.Nombre, f => f.Name.FirstName())
                    .RuleFor(g => g.Apellido, f => f.Name.LastName())
                    .RuleFor(g => g.Correo, f => f.Person.Email)
                    .RuleFor(g => g.Genero, f => f.PickRandom((int)GeneroEnum.Masculino, (int)GeneroEnum.Femenino))
                    .RuleFor(g => g.AñosExperiencia, f => f.Random.Number(1, 10))
                    .RuleFor(g => g.Calificacion, f => f.Random.Number(1, 20))
                    .RuleFor(g => g.FechaNacimiento, f => f.Date.Past())
                    .RuleFor(g => g.IdLineaCarrera, f => f.PickRandom((int)LineaCarreraEnum.BusinessAnalyst, (int)LineaCarreraEnum.SoftwareEngineer, (int)LineaCarreraEnum.DevOpsEngineer,
                        (int)LineaCarreraEnum.MobileEngineer, (int)LineaCarreraEnum.QualityAssurance))
                    .RuleFor(g => g.Photo, f => f.PickRandom("https://randomuser.me/api/portraits/women/47.jpg",
                                                            "https://randomuser.me/api/portraits/women/33.jpg",
                                                            "https://randomuser.me/api/portraits/women/65.jpg",
                                                            "https://randomuser.me/api/portraits/women/38.jpg",
                                                            "https://randomuser.me/api/portraits/women/6.jpg",
                                                            "https://randomuser.me/api/portraits/men/44.jpg",
                                                            "https://randomuser.me/api/portraits/men/72.jpg",
                                                            "https://randomuser.me/api/portraits/men/23.jpg",
                                                            "https://randomuser.me/api/portraits/men/36.jpg",
                                                            "https://randomuser.me/api/portraits/men/52.jpg"))
                    .RuleFor(g => g.IdNivel, f => (int)NivelEnum.Senior)
                    .RuleFor(g => g.ConocimientoIds, f => GenerateRandomConocimientosIds())
                    .RuleFor(g => g.IdSede, f => f.PickRandom((int)SedeEnum.Cochabamba, (int)SedeEnum.Liberia, (int)SedeEnum.Lima, (int)SedeEnum.SanCarlos, (int)SedeEnum.SanJose));
                SherpasVM = new Faker<UsuarioToRegisterVM>()
                    .RuleFor(g => g.Username, f => f.Person.UserName)
                    .RuleFor(g => g.Password, f => "12345")
                    .RuleFor(g => g.IdRol, f => (int)RolEnum.Sherpa)
                    .RuleFor(g => g.Participante, f => Participante).Generate(100);
            }
            return SherpasVM;
        }

        public List<int> GenerateRandomConocimientosIds()
        {
            List<int> conocimientosIds = new List<int>();
            for (int i = 0; i < new Random().Next(1, 20); i++)
            {
                conocimientosIds.Add(new Random().Next(1, 60));
            }
            return conocimientosIds;
        }

        private IList<UsuarioToRegisterVM> EscaladoresVM;
        public IList<UsuarioToRegisterVM> GetEscaladoresVM()
        {
            if (EscaladoresVM == null)
            {
                var Participante = new Faker<ParticipanteToCreateVM>()
                    .RuleFor(g => g.Nombre, f => f.Name.FirstName())
                    .RuleFor(g => g.Apellido, f => f.Name.LastName())
                    .RuleFor(g => g.Correo, f => f.Person.Email)
                    .RuleFor(g => g.Genero, f => f.PickRandom((int)GeneroEnum.Masculino, (int)GeneroEnum.Femenino))
                    .RuleFor(g => g.AñosExperiencia, f => f.Random.Number(1, 10))
                    .RuleFor(g => g.Puntaje, f => f.Random.Number(1, 10000))
                    .RuleFor(g => g.FechaNacimiento, f => f.Date.Past())
                    .RuleFor(g => g.IdLineaCarrera, f => f.PickRandom((int)LineaCarreraEnum.BusinessAnalyst, (int)LineaCarreraEnum.SoftwareEngineer, (int)LineaCarreraEnum.DevOpsEngineer,
                        (int)LineaCarreraEnum.MobileEngineer, (int)LineaCarreraEnum.QualityAssurance))
                    .RuleFor(g => g.IdNivel, f => f.PickRandom((int)NivelEnum.Junior, (int)NivelEnum.NivelUno, (int)NivelEnum.NivelDos,
                        (int)NivelEnum.NivelTres))
                    .RuleFor(g => g.ConocimientoIds, f => GenerateRandomConocimientosIds())
                    .RuleFor(g => g.Photo, f => f.PickRandom("https://randomuser.me/api/portraits/women/47.jpg",
                                                            "https://randomuser.me/api/portraits/women/33.jpg",
                                                            "https://randomuser.me/api/portraits/women/65.jpg",
                                                            "https://randomuser.me/api/portraits/women/38.jpg",
                                                            "https://randomuser.me/api/portraits/women/6.jpg",
                                                            "https://randomuser.me/api/portraits/men/44.jpg",
                                                            "https://randomuser.me/api/portraits/men/72.jpg",
                                                            "https://randomuser.me/api/portraits/men/23.jpg",
                                                            "https://randomuser.me/api/portraits/men/36.jpg",
                                                            "https://randomuser.me/api/portraits/men/52.jpg"))
                    .RuleFor(g => g.IdSede, f => f.PickRandom((int)SedeEnum.Cochabamba, (int)SedeEnum.Liberia, (int)SedeEnum.Lima, (int)SedeEnum.SanCarlos, (int)SedeEnum.SanJose));
                EscaladoresVM = new Faker<UsuarioToRegisterVM>()
                    .RuleFor(g => g.Username, f => f.Person.UserName)
                    .RuleFor(g => g.Password, f => "12345")
                    .RuleFor(g => g.IdRol, f => (int)RolEnum.Escalador)
                    .RuleFor(g => g.Participante, f => Participante).Generate(500);
            }
            return EscaladoresVM;
        }


        private IList<UsuarioToRegisterVM> AdminsVM;
        public IList<UsuarioToRegisterVM> GetAdminsVM()
        {
            if (AdminsVM == null)
            {
                var Participante = new Faker<ParticipanteToCreateVM>()
                    .RuleFor(g => g.Nombre, f => f.Name.FirstName())
                    .RuleFor(g => g.Apellido, f => f.Name.LastName())
                    .RuleFor(g => g.Correo, f => f.Person.Email)
                    .RuleFor(g => g.Genero, f => f.PickRandom((int)GeneroEnum.Masculino, (int)GeneroEnum.Femenino))
                    .RuleFor(g => g.AñosExperiencia, f => f.Random.Number(1, 10))
                    .RuleFor(g => g.Calificacion, f => f.Random.Number(1, 20))
                    .RuleFor(g => g.FechaNacimiento, f => f.Date.Past())
                    .RuleFor(g => g.IdLineaCarrera, f => f.PickRandom((int)LineaCarreraEnum.BusinessAnalyst, (int)LineaCarreraEnum.SoftwareEngineer, (int)LineaCarreraEnum.DevOpsEngineer,
                        (int)LineaCarreraEnum.MobileEngineer, (int)LineaCarreraEnum.QualityAssurance))
                    .RuleFor(g => g.Photo, f => f.PickRandom("https://randomuser.me/api/portraits/women/47.jpg",
                                                            "https://randomuser.me/api/portraits/women/33.jpg",
                                                            "https://randomuser.me/api/portraits/women/65.jpg",
                                                            "https://randomuser.me/api/portraits/women/38.jpg",
                                                            "https://randomuser.me/api/portraits/women/6.jpg",
                                                            "https://randomuser.me/api/portraits/men/44.jpg",
                                                            "https://randomuser.me/api/portraits/men/72.jpg",
                                                            "https://randomuser.me/api/portraits/men/23.jpg",
                                                            "https://randomuser.me/api/portraits/men/36.jpg",
                                                            "https://randomuser.me/api/portraits/men/52.jpg"))
                    .RuleFor(g => g.IdNivel, f => (int)NivelEnum.Senior)
                    .RuleFor(g => g.ConocimientoIds, f => GenerateRandomConocimientosIds())
                    .RuleFor(g => g.IdSede, f => f.PickRandom((int)SedeEnum.Cochabamba, (int)SedeEnum.Liberia, (int)SedeEnum.Lima, (int)SedeEnum.SanCarlos, (int)SedeEnum.SanJose));
                AdminsVM = new Faker<UsuarioToRegisterVM>()
                    .RuleFor(g => g.Username, f => f.Person.UserName)
                    .RuleFor(g => g.Password, f => "12345")
                    .RuleFor(g => g.IdRol, f => (int)RolEnum.Administrador)
                    .RuleFor(g => g.Participante, f => Participante).Generate(1);
            }
            return AdminsVM;
        }


    }
}

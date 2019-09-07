using Bogus;
using EverestLMS.Common.Enums;
using EverestLMS.ViewModels.Participante;
using System;
using System.Collections.Generic;

namespace EverestLMS.Common.Fakes
{
    public class ParticipanteFaker
    {
        private ParticipanteToCreateVM SherpaToCreateVM;
        public ParticipanteToCreateVM GetSherpaToCreateVM()
        {
            if (SherpaToCreateVM == null)
            {
                SherpaToCreateVM = new Faker<ParticipanteToCreateVM>()
                    .RuleFor(g => g.Nombre, f => f.Name.FirstName())
                    .RuleFor(g => g.Apellido, f => f.Name.LastName())
                    .RuleFor(g => g.Correo, f => f.Person.Email)
                    .RuleFor(g => g.Genero, f => f.PickRandom((int)GeneroEnum.Masculino, (int)GeneroEnum.Femenino))
                    .RuleFor(g => g.AñosExperiencia, f => f.Random.Number(1, 10))
                    .RuleFor(g => g.Calificacion, f => f.Random.Number(1, 20))
                    .RuleFor(g => g.FechaNacimiento, f => f.Date.Past())
                    .RuleFor(g => g.IdLineaCarrera, f => f.PickRandom((int)LineaCarreraEnum.BusinessAnalyst, (int)LineaCarreraEnum.SoftwareEngineer, (int)LineaCarreraEnum.DevOpsEngineer,
                        (int)LineaCarreraEnum.MobileEngineer, (int)LineaCarreraEnum.QualityAssurance))
                    .RuleFor(g => g.IdNivel, f => (int)NivelEnum.Senior)
                    .RuleFor(g => g.Rol, f => (int)RolEnum.Sherpa);
            }
            return SherpaToCreateVM;
        }

        private ParticipanteToCreateVM EscaladorToCreateVM;
        public ParticipanteToCreateVM GetEscaladorToCreateVM()
        {
            if (EscaladorToCreateVM == null)
            {
                EscaladorToCreateVM = new Faker<ParticipanteToCreateVM>()
                    .RuleFor(g => g.Nombre, f => f.Name.FirstName())
                    .RuleFor(g => g.Apellido, f => f.Name.LastName())
                    .RuleFor(g => g.Correo, f => f.Person.Email)
                    .RuleFor(g => g.Genero, f => f.PickRandom((int)GeneroEnum.Masculino, (int)GeneroEnum.Femenino))
                    .RuleFor(g => g.AñosExperiencia, f => f.Random.Number(1, 10))
                    .RuleFor(g => g.Calificacion, f => f.Random.Number(1, 20))
                    .RuleFor(g => g.FechaNacimiento, f => f.Date.Past())
                    .RuleFor(g => g.IdLineaCarrera, f => f.PickRandom((int)LineaCarreraEnum.BusinessAnalyst, (int)LineaCarreraEnum.SoftwareEngineer, (int)LineaCarreraEnum.DevOpsEngineer,
                        (int)LineaCarreraEnum.MobileEngineer, (int)LineaCarreraEnum.QualityAssurance))
                    .RuleFor(g => g.IdNivel, f => (int)NivelEnum.Senior)
                    .RuleFor(g => g.Rol, f => (int)RolEnum.Sherpa);
            }
            return EscaladorToCreateVM;
        }

        public IList<ParticipanteToCreateVM> SherpasVM;
        public IList<ParticipanteToCreateVM> GetSherpasVM()
        {
            if (SherpasVM == null)
            {
                SherpasVM = new Faker<ParticipanteToCreateVM>()
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
                    .RuleFor(g => g.IdSede, f => f.PickRandom((int)SedeEnum.Cochabamba, (int)SedeEnum.Liberia, (int)SedeEnum.Lima, (int)SedeEnum.SanCarlos, (int)SedeEnum.SanJose))
                    .RuleFor(g => g.Rol, f => (int)RolEnum.Sherpa).Generate(100);
            }
            return SherpasVM;
        }

        private List<int> GenerateRandomConocimientosIds()
        {
            List<int> conocimientosIds = new List<int>();
            for (int i = 0; i < new Random().Next(1, 20); i++)
            {
                conocimientosIds.Add(new Random().Next(1, 60));
            }
            return conocimientosIds;
        }

        public IList<ParticipanteToCreateVM> EscaladoresVM;
        public IList<ParticipanteToCreateVM> GetEscaladoresVM()
        {
            if (EscaladoresVM == null)
            {
                EscaladoresVM = new Faker<ParticipanteToCreateVM>()
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
                    .RuleFor(g => g.IdSede, f => f.PickRandom((int)SedeEnum.Cochabamba, (int)SedeEnum.Liberia, (int)SedeEnum.Lima, (int)SedeEnum.SanCarlos, (int)SedeEnum.SanJose))
                    .RuleFor(g => g.Rol, f => (int)RolEnum.Escalador).Generate(500);
            }
            return EscaladoresVM;
        }

    }
}

using System;
using System.Collections.Generic;

namespace EverestLMS.Entities.Models
{
    public class ParticipanteEntity
    {
        public ParticipanteEntity()
        {
            ConocimientoParticipantes = new HashSet<ConocimientoParticipanteEntity>();
            InverseIdSherpaNavigation = new HashSet<ParticipanteEntity>();
        }

        public int IdParticipante { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int? AñosExperiencia { get; set; }
        public decimal? Calificacion { get; set; }
        public int? Rol { get; set; }
        public int? Puntaje { get; set; }
        public int? IdSherpa { get; set; }
        public int IdNivel { get; set; }
        public int IdLineaCarrera { get; set; }
        public int Activo { get; set; }
        public string Photo { get; set; }
        public int IdSede { get; set; }
        public string UsuarioKey { get; set; }

        public LineaCarreraEntity IdLineaCarreraNavigation { get; set; }
        public NivelEntity IdNivelNavigation { get; set; }
        public ParticipanteEntity IdSherpaNavigation { get; set; }
        public ICollection<ConocimientoParticipanteEntity> ConocimientoParticipantes { get; set; }
        public ICollection<ParticipanteEntity> InverseIdSherpaNavigation { get; set; }
    }
}

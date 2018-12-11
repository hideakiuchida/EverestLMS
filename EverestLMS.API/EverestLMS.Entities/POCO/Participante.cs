using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.Entities.POCO
{
    public class Participante
    {
        public Participante()
        {
            ConocimientoParticipantes = new HashSet<ConocimientoParticipante>();
            InverseIdSherpaNavigation = new HashSet<Participante>();
        }

        public int IdParticipante { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int? AñosExperiencia { get; set; }
        public decimal? Calificacion { get; set; }
        public int? Puntaje { get; set; }
        public int? Rol { get; set; }
        public int? IdSherpa { get; set; }
        public int IdNivel { get; set; }
        public int IdLineaCarrera { get; set; }
        public int Activo { get; set; }
        public string Photo { get; set; }
        public string Sede { get; set; }

        public LineaCarrera IdLineaCarreraNavigation { get; set; }
        public Nivel IdNivelNavigation { get; set; }
        public Participante IdSherpaNavigation { get; set; }
        public ICollection<ConocimientoParticipante> ConocimientoParticipantes { get; set; }
        public ICollection<Participante> InverseIdSherpaNavigation { get; set; }
    }
}

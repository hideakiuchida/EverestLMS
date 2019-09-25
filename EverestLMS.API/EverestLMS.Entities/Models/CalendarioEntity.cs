using System;

namespace EverestLMS.Entities.Models
{
    public class CalendarioEntity
    {
        public int IdCalendario { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public bool Activo { get; set; }
        public string Temporada { get; set; }
    }
}

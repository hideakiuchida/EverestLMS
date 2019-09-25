using System;

namespace EverestLMS.ViewModels.Calendario
{
    public class CalendarioVM
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public bool Activo { get; set; }
        public string Temporada { get; set; }
    }
}

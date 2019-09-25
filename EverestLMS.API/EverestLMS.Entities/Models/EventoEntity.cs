using System;

namespace EverestLMS.Entities.Models
{
    public class EventoEntity
    {
        public int IdEvento { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string ColorPrimario { get; set; }
        public string ColorSecundario { get; set; }
        public int IdCalendario { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.Entities.Models
{
    public class RespuestaEscaladorEntity
    {
        public int Id { get; set; }
        public int IdPregunta { get; set; }
        public string DescripcionPregunta { get; set; }
        public int IdRespuesta { get; set; }
        public string DescripcionRespuesta { get; set; }
        public bool? MarcoCorrecto { get; set; }
        public int IdLeccion { get; set; }
        public int NumeroOrden { get; set; }
    }
}

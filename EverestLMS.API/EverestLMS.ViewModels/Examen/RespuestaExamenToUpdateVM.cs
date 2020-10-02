using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.ViewModels.Examen
{
    public class RespuestaExamenToUpdateVM
    {
        public int IdPregunta { get; set; }
        public string DescripcionPregunta { get; set; }
        public int IdRespuesta { get; set; }
        public string DescripcionRespuesta { get; set; }
    }
}

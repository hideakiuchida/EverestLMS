using EverestLMS.ViewModels.Leccion;
using System.Collections.Generic;

namespace EverestLMS.ViewModels.Examen
{
    public class PreguntaExamenVM
    {
        public int IdRespuestaEscalador { get; set; }
        public int IdPregunta { get; set; }
        public string DescripcionPregunta { get; set; }
        public string Imagen { get; set; }
        public int NumeroOrden { get; set; }
        public IEnumerable<RespuestaVM> Respuestas { get; set; }
    }
}

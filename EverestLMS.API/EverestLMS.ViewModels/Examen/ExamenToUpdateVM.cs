using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.ViewModels.Examen
{
    public class ExamenToUpdateVM
    {
        public string UsuarioKey { get; set; }
        public int IdEtapa { get; set; }
        public int IdCurso { get; set; }
        public int? IdLeccion { get; set; }
        public int VidasRestante { get; set; }
        public int TiempoRestante { get; set; }
        public int NumeroPreguntaActual { get; set; }
        public bool Finalizado { get; set; }
    }
}

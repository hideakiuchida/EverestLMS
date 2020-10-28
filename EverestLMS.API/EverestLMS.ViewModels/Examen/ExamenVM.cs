using System;

namespace EverestLMS.ViewModels.Examen
{
    public class ExamenVM
    {
        public int Id { get; set; }
        public int IdEtapa { get; set; }
        public int IdCurso { get; set; }
        public int? IdLeccion { get; set; }
        public decimal Nota { get; set; }
        public int VidasRestante { get; set; }
        public int TiempoRestante { get; set; }
        public int NumeroPreguntaActual { get; set; }
        public DateTime? FechaFinalizado { get; set; }
        public int TotalPreguntas { get; set; }
    }
}

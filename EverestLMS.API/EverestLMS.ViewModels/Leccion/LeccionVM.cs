using System;

namespace EverestLMS.ViewModels.Leccion
{
    public class LeccionVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ContenidoHTML { get; set; }
        public int IdDificultad { get; set; }
        public int Puntaje { get; set; }
        public int NumeroOrden { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdCurso { get; set; }
        public int IdEtapa { get; set; }
    }
}

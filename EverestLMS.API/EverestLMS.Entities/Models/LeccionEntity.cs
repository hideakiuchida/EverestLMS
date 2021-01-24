using System;

namespace EverestLMS.Entities.Models
{
    public class LeccionEntity
    {
        public int IdLeccion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ContenidoHTML { get; set; }
        public int? Puntaje { get; set; }
        public int NumeroOrden { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdCurso { get; set; }
        public int IdEtapa { get; set; }
    }
}

using System;

namespace EverestLMS.Entities.Models
{
    public class CursoEntity
    {
        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdDificultad { get; set; }
        public int Idioma { get; set; }
        public int Puntaje { get; set; }
        public string Imagen { get; set; }
        public string Autor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string NombreEtapa { get; set; }
        public int IdEtapa { get; set; }
    }
}

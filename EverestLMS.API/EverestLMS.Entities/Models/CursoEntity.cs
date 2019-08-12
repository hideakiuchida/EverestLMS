using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.Entities.Models
{
    public class CursoEntity
    {
        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Dificultad { get; set; }
        public int Idioma { get; set; }
        public int Puntaje { get; set; }
        public string Imagen { get; set; }
        public string Autor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdEtapa { get; set; }
    }
}

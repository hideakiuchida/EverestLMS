using EverestLMS.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace EverestLMS.ViewModels.Curso
{
    public class CursoVM
    {
        public int Id{ get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required]
        [Range((int)DificultadEnum.Facil, (int)DificultadEnum.Dificil, ErrorMessage = "El campo IdDificultad solo puede contener valores entre 1 y 3")]
        public int IdDificultad { get; set; }
        [Required]
        [Range((int)IdiomaEnum.Ingles, (int)IdiomaEnum.Espanol, ErrorMessage = "El campo Idioma solo puede contener valores entre 1 y 2")]
        public int Idioma { get; set; }
        [Required]
        public int Puntaje { get; set; }
        [Required]
        public string Imagen { get; set; }
        [Required]
        public string Autor { get; set; }
        public int IdEtapa { get; set; }
    }
}

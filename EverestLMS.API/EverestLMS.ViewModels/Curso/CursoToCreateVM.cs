using EverestLMS.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace EverestLMS.ViewModels.Curso
{
    public class CursoToCreateVM
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        [Range((int)DificultadEnum.Facil, (int)DificultadEnum.Dificil, ErrorMessage = "El campo IdDificultad solo puede contener valores entre 1 y 3")]
        public int IdDificultad { get; set; }
        [Required]
        [Range((int)IdiomaEnum.Ingles, (int)IdiomaEnum.Espanol, ErrorMessage = "El campo IdIdioma solo puede contener valores entre 1 y 2")]
        public int IdIdioma { get; set; }
        [Required]
        public int Puntaje { get; set; }
        public string Imagen { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        public int IdEtapa { get; set; }
    }
}

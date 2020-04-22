using System.ComponentModel.DataAnnotations;

namespace EverestLMS.ViewModels.Leccion
{
    public class RespuestaToCreateVM
    {
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public bool EsCorrecto { get; set; }
        public int IdPregunta { get; set; }
    }
}

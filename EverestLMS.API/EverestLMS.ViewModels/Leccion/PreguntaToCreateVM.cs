using System.ComponentModel.DataAnnotations;

namespace EverestLMS.ViewModels.Leccion
{
    public class PreguntaToCreateVM
    {
        [Required]
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public int IdLeccion { get; set; }
    }
}

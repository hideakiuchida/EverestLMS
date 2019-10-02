using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EverestLMS.ViewModels.Leccion
{
    public class LeccionMaterialVideoToCreateVM
    {
        [Required]
        public IFormFile File { get; set; }
        public string Titulo { get; set; }
        public int IdTipoContenido { get; set; }
        public int IdLeccion { get; set; }
    }
}

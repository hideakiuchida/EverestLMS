using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EverestLMS.ViewModels.CloudinaryFile
{
    public class CloudinaryFileToCreateVM
    {
        [Required]
        public IFormFile File { get; set; }
        public string Descripcion { get; set; }
        public int? IdCurso { get; set; }
        public int? IdLeccion { get; set; }
        public int? IdPregunta { get; set; }
        public int? IdRespuesta { get; set; }
        public int? IdUsuario { get; set; }
    }
}

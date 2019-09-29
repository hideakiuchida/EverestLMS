using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EverestLMS.ViewModels.CloudinaryFile
{
    public class CloudinaryFileToCreateVM
    {
        [Required]
        public IFormFile File { get; set; }
        public string Descripcion { get; set; }
        public int? IdReferencia { get; set; }
    }
}

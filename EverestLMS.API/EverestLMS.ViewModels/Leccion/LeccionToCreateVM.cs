using System.ComponentModel.DataAnnotations;

namespace EverestLMS.ViewModels.Leccion
{
    public class LeccionToCreateVM
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public string ContenidoHTML { get; set; }
        [Required]
        public int Puntaje { get; set; }
        
        public int IdCurso { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EverestLMS.ViewModels.Leccion
{
    public class LeccionToUpdateVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int IdCurso { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ContenidoHTML { get; set; }
        public int? Puntaje { get; set; }   
    }
}

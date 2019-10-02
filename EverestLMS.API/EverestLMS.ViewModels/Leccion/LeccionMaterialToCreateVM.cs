using EverestLMS.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace EverestLMS.ViewModels.Leccion
{
    public class LeccionMaterialToCreateVM
    {
        [Required]
        public string Titulo { get; set; }
        public string ContenidoTexto { get; set; }
        [Required]
        [Range((int)TipoContenidoEnum.Lectura, (int)TipoContenidoEnum.Presentacion, ErrorMessage = "El campo IdTipoContenido solo puede contener valores entre 1 y 3")]
        public int IdTipoContenido { get; set; }
        public int IdLeccion { get; set; }
    }
}

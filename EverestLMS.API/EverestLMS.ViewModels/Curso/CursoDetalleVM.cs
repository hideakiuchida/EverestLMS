using EverestLMS.ViewModels.Leccion;
using System.Collections.Generic;

namespace EverestLMS.ViewModels.Curso
{
    public class CursoDetalleVM : CursoVM
    {
        public string DescripcionEtapa { get; set; }
        public string DificultadDescripcion { get; set; }
        public string IdiomaDescripcion { get; set; }
        public string LineaCarreraDescripcion { get; set; }
        public string NivelDescripcion { get; set; }
        public IEnumerable<LeccionDetalleVM> Lecciones { get; set; }
    }
}

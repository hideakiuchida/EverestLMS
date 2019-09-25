using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.Entities.Models
{
    public class CursoDetalleEntity : CursoEntity
    {
        public string DescripcionEtapa { get; set; }
        public string NombreEtapa { get; set; }
        public string DificultadDescripcion { get; set; }
        public string IdiomaDescripcion { get; set; }
        public string LineaCarreraDescripcion { get; set; }
        public string NivelDescripcion { get; set; }
    }
}

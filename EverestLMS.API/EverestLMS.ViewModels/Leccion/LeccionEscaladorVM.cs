using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.ViewModels.Leccion
{
    public class LeccionEscaladorVM
    {
        public int Id { get; set; }
        public int IdEtapa { get; set; }
        public int IdCurso { get; set; }
        public string IdParticipante { get; set; }
        public string CursoImagenUrl { get; set; }
        public string CursoNombre { get; set; }
        public string Nombre { get; set; }
        public string ContenidoHTML { get; set; }
    }
}

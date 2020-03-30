using System.Collections.Generic;

namespace EverestLMS.ViewModels.Curso
{
    public class CursoPredictedByParticipantVM
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<CursoPredictionVM> Cursos { get; set; }
    }
}

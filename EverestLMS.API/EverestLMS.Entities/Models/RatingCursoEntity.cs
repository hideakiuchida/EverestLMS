using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.Entities.Models
{
    public class RatingCursoEntity
    {
        public int IdRatingCurso { get; set; }
        public int Rating { get; set; }
        public int IdParticipante { get; set; }
        public int IdCurso { get; set; }
    }
}

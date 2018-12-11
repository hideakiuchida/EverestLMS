using EverestLMS.ViewModels.Participante.Escalador;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.ViewModels.Participante.Sherpa
{
    public class SherpaVM : ParticipanteVM
    {
        public int? AñosExperiencia { get; set; }
        public decimal? Calificacion { get; set; }
        public ICollection<EscaladorLiteVM> Escaladores { get; set;}
    }
}

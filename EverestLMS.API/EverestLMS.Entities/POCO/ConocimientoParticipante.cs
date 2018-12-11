using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.Entities.POCO
{
    public partial class ConocimientoParticipante
    {
        public int IdConocimientoParticipante { get; set; }
        public int IdConocimiento { get; set; }
        public int IdParticipante { get; set; }

        public Conocimiento IdConocimientoNavigation { get; set; }
        public Participante IdParticipanteNavigation { get; set; }
    }
}

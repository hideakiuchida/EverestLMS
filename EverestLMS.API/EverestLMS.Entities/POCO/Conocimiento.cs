using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.Entities.POCO
{
    public class Conocimiento
    {
        public Conocimiento()
        {
            ConocimientoParticipantes = new HashSet<ConocimientoParticipante>();
        }

        public int IdConocimiento { get; set; }
        public string Descripcion { get; set; }

        public ICollection<ConocimientoParticipante> ConocimientoParticipantes { get; set; }
    }
}

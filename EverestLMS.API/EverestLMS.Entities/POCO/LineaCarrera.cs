using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.Entities.POCO
{
    public class LineaCarrera
    {
        public LineaCarrera()
        {
            Participante = new HashSet<Participante>();
        }

        public int IdLineaCarrera { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Participante> Participante { get; set; }
    }
}

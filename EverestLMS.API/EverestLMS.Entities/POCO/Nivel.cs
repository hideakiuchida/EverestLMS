using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.Entities.POCO
{
    public class Nivel
    {
        public Nivel()
        {
            Participante = new HashSet<Participante>();
        }

        public int IdNivel { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Participante> Participante { get; set; }
    }
}

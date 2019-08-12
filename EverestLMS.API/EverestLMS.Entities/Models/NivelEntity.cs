using System.Collections.Generic;

namespace EverestLMS.Entities.Models
{
    public class NivelEntity
    {
        public NivelEntity()
        {
            Participante = new HashSet<ParticipanteEntity>();
        }

        public int IdNivel { get; set; }
        public string Descripcion { get; set; }

        public ICollection<ParticipanteEntity> Participante { get; set; }
    }
}

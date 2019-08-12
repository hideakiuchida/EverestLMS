using System.Collections.Generic;

namespace EverestLMS.Entities.Models
{
    public class LineaCarreraEntity
    {
        public LineaCarreraEntity()
        {
            Participante = new HashSet<ParticipanteEntity>();
        }

        public int IdLineaCarrera { get; set; }
        public string Descripcion { get; set; }

        public ICollection<ParticipanteEntity> Participante { get; set; }
    }
}

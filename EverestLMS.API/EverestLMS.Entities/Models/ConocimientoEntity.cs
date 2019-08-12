using System.Collections.Generic;

namespace EverestLMS.Entities.Models
{
    public class ConocimientoEntity
    {
        public ConocimientoEntity()
        {
            ConocimientoParticipantes = new HashSet<ConocimientoParticipanteEntity>();
        }

        public int IdConocimiento { get; set; }
        public string Descripcion { get; set; }

        public ICollection<ConocimientoParticipanteEntity> ConocimientoParticipantes { get; set; }
    }
}

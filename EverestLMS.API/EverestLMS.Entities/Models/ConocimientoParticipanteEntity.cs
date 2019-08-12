namespace EverestLMS.Entities.Models
{
    public partial class ConocimientoParticipanteEntity
    {
        public int IdConocimientoParticipante { get; set; }
        public int IdConocimiento { get; set; }
        public int IdParticipante { get; set; }

        public ConocimientoEntity IdConocimientoNavigation { get; set; }
        public ParticipanteEntity IdParticipanteNavigation { get; set; }
    }
}

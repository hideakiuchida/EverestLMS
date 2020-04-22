namespace EverestLMS.Entities.Models
{
    public class RespuestaEntity
    {
        public int IdRespuesta { get; set; }
        public string Descripcion { get; set; }
        public bool EsCorrecto { get; set; }
        public int IdPregunta { get; set; }
    }
}

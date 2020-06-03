namespace EverestLMS.Entities.Models
{
    public class LeccionMaterialDetalleEntity : LeccionMaterialEntity
    {
        public string IdPublico { get; set; }
        public string Url { get; set; }
        public string ContenidoTexto { get; set; }
    }
}

namespace EverestLMS.Entities.Models
{
    public class CloudinaryFileEntity
    {
        public int IdCloudinaryFile { get; set; }
        public string Descripcion { get; set; }
        public string IdPublico { get; set; }
        public string Url { get; set; }
        public int? IdReferencia { get; set; }
    }
}

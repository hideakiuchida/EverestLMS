namespace EverestLMS.Entities.Models
{
    public class CloudinaryFileEntity
    {
        public int IdCloudinaryFile { get; set; }
        public string Descripcion { get; set; }
        public string IdPublico { get; set; }
        public string Url { get; set; }
        public int? IdCurso{ get; set; }
        public int? IdLeccion { get; set; }
        public int? IdPregunta { get; set; }
        public int? IdRespuesta { get; set; }
        public int? IdUsuario { get; set; }
    }
}

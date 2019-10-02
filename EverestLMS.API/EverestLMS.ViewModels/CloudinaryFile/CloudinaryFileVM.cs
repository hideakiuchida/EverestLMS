namespace EverestLMS.ViewModels.CloudinaryFile
{
    public class CloudinaryFileVM
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string IdPublico { get; set; }
        public string Url { get; set; }
        public int? IdCurso { get; set; }
        public int? IdPregunta { get; set; }
        public int? IdRespuesta { get; set; }
        public int? IdUsuario { get; set; }
    }
}

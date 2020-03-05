namespace EverestLMS.ViewModels.Leccion
{
    public class LeccionMaterialDetalleVM
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string IdPublico { get; set; }
        public string Url { get; set; }
        public string ContenidoTexto { get; set; }
        public int IdTipoContenido { get; set; }
        public int IdLeccion { get; set; }
    }
}

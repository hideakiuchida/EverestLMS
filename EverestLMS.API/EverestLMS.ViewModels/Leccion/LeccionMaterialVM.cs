namespace EverestLMS.ViewModels.Leccion
{
    public class LeccionMaterialVM
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string ContenidoTexto { get; set; }
        public string TipoContenidoDescripcion { get; set; }
        public int IdLeccion { get; set; }
        public int IdTipoContenido { get; set; }
        public string Url { get; set; }
    }
}

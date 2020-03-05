namespace EverestLMS.ViewModels.Curso
{
    public class CursoVM
    {
        public int Id{ get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdDificultad { get; set; }
        public int Idioma { get; set; }
        public int Puntaje { get; set; }
        public string Imagen { get; set; }
        public string Autor { get; set; }
        public string NombreEtapa { get; set; }
        public int IdEtapa { get; set; }
    }
}

namespace EverestLMS.Entities.Models
{
    public class LeccionDetalleEntity : LeccionEntity
    {
        public string CursoDescripcion { get; set; }
        public string IdiomaDescripcion { get; set; }
        public string EtapaDescripcion { get; set; }
        public string NombreEtapa { get; set; }
        public string NivelDescripcion { get; set; }
        public string LineaCarreraDescripcion { get; set; }
        public string DificultadDescripcion { get; set; }
        public string Autor { get; set; }
    }
}

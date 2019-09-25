namespace EverestLMS.ViewModels.Calendario
{
    public class CriterioAceptacionVM
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Medida { get; set; }
        public decimal? Valor { get; set; }
        public int IdCalendario { get; set; }
    }
}

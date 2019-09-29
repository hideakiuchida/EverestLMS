using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EverestLMS.ViewModels.Curso
{
    public class CursoToUpdateVM : CursoToCreateVM
    {
        public int Id { get; set; }
        public int IdLineaCarrera { get; set; }
        public int IdNivel { get; set; }
    }
}

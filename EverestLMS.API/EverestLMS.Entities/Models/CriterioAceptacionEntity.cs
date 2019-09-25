using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.Entities.Models
{
    public class CriterioAceptacionEntity
    {
        public int IdCriterioAceptacion { get; set; }
        public string Descripcion { get; set; }
        public string Medida { get; set; }
        public decimal? Valor { get; set; }
        public int IdCalendario { get; set; }
    }
}

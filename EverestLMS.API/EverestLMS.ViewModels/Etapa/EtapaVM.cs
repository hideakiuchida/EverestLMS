using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.ViewModels.Etapa
{
    public class EtapaVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int NumeroOrden { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdNivel { get; set; }
        public int IdLineaCarrera { get; set; }
    }
}

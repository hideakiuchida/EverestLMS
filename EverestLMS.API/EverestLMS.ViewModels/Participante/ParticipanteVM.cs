using EverestLMS.ViewModels.Conocimiento;
using System;
using System.Collections.Generic;

namespace EverestLMS.ViewModels.Participante
{
    public class ParticipanteVM
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }     
        public int? Rol { get; set; }
        public int? IdSherpa { get; set; }
        public string Nivel { get; set; }
        public string LineaCarrera { get; set; }
        public string Photo { get; set; }
        public int IdLineaCarrera { get; set; }
        public int IdNivel { get; set; }
        public string Sede { get; set; }

        public ICollection<ConocimientoVM> Conocimientos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EverestLMS.ViewModels.Participante
{
    public class ParticipanteToCreateVM
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public int Genero { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public int? AñosExperiencia { get; set; }
        public decimal? Calificacion { get; set; }
        public int? Puntaje { get; set; }
        [Required]
        public int IdNivel { get; set; }
        [Required]
        public int IdLineaCarrera { get; set; }
        [Required]
        public int IdSede { get; set; }
        public string Photo { get; set; }

        [Required]
        public List<int> ConocimientoIds { get; set; }
    }
}

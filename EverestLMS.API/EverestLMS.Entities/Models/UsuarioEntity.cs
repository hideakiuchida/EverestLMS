using System;
using System.Collections.Generic;
using System.Text;

namespace EverestLMS.Entities.Models
{
    public class UsuarioEntity
    {
        public int IdUsuario { get; set; }
        public string UsuarioKey { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public bool Activo { get; set; }
        public int IdRol { get; set; }
        public int IdParticipante { get; set; }
    }
}

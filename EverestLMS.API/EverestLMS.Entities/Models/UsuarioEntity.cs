namespace EverestLMS.Entities.Models
{
    public class UsuarioEntity
    {
        public int IdUsuario { get; set; }
        public string UsuarioKey { get; set; }
        public string Username { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Activo { get; set; }
        public int IdRol { get; set; }
        public int IdParticipante { get; set; }
        public int Puntaje { get; set; }
    }
}

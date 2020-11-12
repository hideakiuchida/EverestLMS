namespace EverestLMS.ViewModels.Authentication
{
    public class UsuarioVM
    {    
        public string UsuarioKey { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public bool Activo { get; set; }       
        public int IdRol { get; set; }
        public int IdParticipante { get; set; }
        public int Puntaje { get; set; }
    }
}

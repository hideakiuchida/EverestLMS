using EverestLMS.ViewModels.Participante;

namespace EverestLMS.ViewModels.Authentication
{
    public class UsuarioToRegisterVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
        public ParticipanteToCreateVM Participante { get; set; }
    }
}

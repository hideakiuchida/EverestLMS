using EverestLMS.Common.Enums;
using EverestLMS.ViewModels.Participante;
using System.ComponentModel.DataAnnotations;

namespace EverestLMS.ViewModels.Authentication
{
    public class UsuarioToRegisterVM
    {
        [Required]
        [StringLength(50, ErrorMessage = "El campo de username solo puede tener un máximo de 50 caracteres.")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Range((int)RolEnum.Sherpa, (int)RolEnum.Administrador, ErrorMessage = "El campo IdRol solo puede contener valores entre 1 y 3")]
        public int IdRol { get; set; }
        public ParticipanteToCreateVM Participante { get; set; }
    }
}

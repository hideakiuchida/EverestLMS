using EverestLMS.ViewModels.Authentication;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<int> Register(UsuarioToRegisterVM usuarioToRegisterVM);
        Task<UsuarioVM> Login(string username, string password);
    }
}

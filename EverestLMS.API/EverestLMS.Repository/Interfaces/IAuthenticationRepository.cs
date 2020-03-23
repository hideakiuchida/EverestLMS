using EverestLMS.Entities.Models;
using System.Threading.Tasks;

namespace EverestLMS.Repository.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<int> Register(UsuarioEntity usuarioEntity, string password);
        Task<UsuarioEntity> GetUsuarioByUsername(string username);
        Task<bool> UserExists(string username);
    }
}

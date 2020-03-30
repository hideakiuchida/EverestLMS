using EverestLMS.ViewModels.Etapa;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface IEtapaService
    {
        Task<IEnumerable<EtapaVM>> GetAllAsync(int? idNivel, int? idLineaCarrera, string search);
        Task<IEnumerable<EtapaVM>> GetByParticipanteAsync(string idParticipante);
    }
}

using EverestLMS.ViewModels.Curso;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface ICursoService
    {
        Task<IEnumerable<CursoPredictionVM>> GetCursosPredictionByParticipantAsync(int id);
        Task<IEnumerable<CursoPredictedByParticipantVM>> GetAllCursosPredictionByParticipantAsync();
    }
}

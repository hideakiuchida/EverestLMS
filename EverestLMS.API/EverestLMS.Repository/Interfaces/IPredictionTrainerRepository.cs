using EverestLMS.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EverestLMS.Repository.Interfaces
{
    public interface IPredictionTrainerRepository
    {
        Task<int> CreatePredictionCourseForParticipantAsync(RatingCursoEntity ratingCursoEntity);
        Task ClearPredictionsAsync();
    }
}

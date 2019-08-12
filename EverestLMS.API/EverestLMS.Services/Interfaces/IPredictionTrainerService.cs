using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EverestLMS.Services.Interfaces
{
    public interface IPredictionTrainerService
    {
        Task<bool> CreatePredictionCoursesForParticipants();
    }
}

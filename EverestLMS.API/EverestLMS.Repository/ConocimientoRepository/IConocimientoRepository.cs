using EverestLMS.Entities.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EverestLMS.Repository.ConocimientoRepository
{
    public interface IConocimientoRepository
    {
        Task<Conocimiento> GetByIdAsync(int id);
    }
}

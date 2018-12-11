using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EverestLMS.DataAccess;
using EverestLMS.Entities.POCO;
using Microsoft.EntityFrameworkCore;

namespace EverestLMS.Repository.ConocimientoRepository
{
    public class ConocimientoRepository : IConocimientoRepository
    {
        private readonly everestlmsContext context;

        public ConocimientoRepository(everestlmsContext context) 
        {
            this.context = context;
        }

        public async Task<Conocimiento> GetByIdAsync(int id)
        {
            var conocimiento = await context.Conocimiento.FirstOrDefaultAsync(x => x.IdConocimiento == id);
            return conocimiento;
        }
    }
}

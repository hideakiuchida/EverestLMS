using EverestLMS.Common.Enums;
using EverestLMS.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EverestLMS.Entities.POCO;

namespace EverestLMS.Repository.Participante
{
    public class ParticipanteRepository : EverestRepository<Entities.POCO.Participante>, IParticipanteRepository
    {
        private readonly everestlmsContext context;

        public ParticipanteRepository(everestlmsContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> AsignarAsync(int idEscalador, int idSherpa)
        {
            var escalador = await GetByIdAsync(idEscalador);
            escalador.IdSherpa = idSherpa;
            var success = await UpdateAsync(escalador);
            return success;
        }

        public async Task<bool> AsignarAutomaticamenteAsync(IEnumerable<Entities.POCO.Participante> escaladores)
        {
            context.Participante.UpdateRange(escaladores);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DesasignarAsync(int idEscalador)
        {
            var escalador = await GetByIdAsync(idEscalador);
            escalador.IdSherpa = null;
            var success = await UpdateAsync(escalador);
            return success;
        }

        public async Task<Entities.POCO.Participante> GetByIdAsync(int id)
        {
            return await context.Set<Entities.POCO.Participante>().Include(cp => cp.ConocimientoParticipantes)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.IdParticipante == id);
        }

        public async Task<IEnumerable<Entities.POCO.Participante>> GetEscaladoresNoAsignadosAsync(int idLineaCarrera, string search = null)
        {
            var escaladores = await context.Participante.Where(x => x.Rol == (int)RolEnum.Escalador && x.IdSherpa == null && x.Activo == (int)EstadoEnum.Activo
            && x.IdLineaCarrera == idLineaCarrera).ToListAsync();
            if (!string.IsNullOrEmpty(search))
                escaladores = escaladores.Where(x => (x.Nombre + " " + x.Apellido).ToLower().Contains(search.ToLower())).ToList();
            return escaladores;
        }

        public async Task<IEnumerable<Entities.POCO.Participante>> GetEscaladoresPorSherpaIdAsync(int id)
        {
            var escaladores = await context.Participante.Where(x => x.Rol == (int)RolEnum.Escalador && x.IdSherpa == id && x.Activo == (int)EstadoEnum.Activo).ToListAsync();
            return escaladores;
        }

        public async Task<IEnumerable<Entities.POCO.Participante>> GetSherpasAsync(int? idNivel = null, int? idLineaCarrera = null, string search = null)
        {           
            var sherpas = await context.Participante.Where(x => x.Rol == (int)RolEnum.Sherpa && x.Activo == (int)EstadoEnum.Activo
                   && x.IdNivel == (idNivel == null ? x.IdNivel : idNivel)
                   && x.IdLineaCarrera == (idLineaCarrera == null ? x.IdLineaCarrera : idLineaCarrera)).ToListAsync();
            if (!string.IsNullOrEmpty(search))
                sherpas = sherpas.Where(x => (x.Nombre + " " + x.Apellido).ToLower().Contains(search.ToLower())).ToList();
            return sherpas; 
        }
    }
}

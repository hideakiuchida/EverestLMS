using Dapper;
using EverestLMS.Common.Enums;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class ParticipanteRepository : BaseConnection, IParticipanteRepository
    {
        public ParticipanteRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
        public async Task<bool> AsignarAsync(string idEscalador, string idSherpa)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<bool>("AsignarSherpa", new { IdEscalador = idEscalador, IdSherpa = idSherpa },
            commandType: CommandType.StoredProcedure);
            _dbConnection.Close();
            return result.FirstOrDefault();
        }

        public async Task<bool> AsignarAutomaticamenteAsync(int idSherpa, int[] idsEscaladores)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("IdEscaladores", typeof(int));
            if (idsEscaladores != null)
                idsEscaladores.ToList().ForEach(item => dataTable.Rows.Add(item));
            var result = await _dbConnection.QueryAsync<bool>("AsignarAutomaticamente", new
            {
                IdSherpa = idSherpa,
                IdEscaladores = dataTable.AsTableValuedParameter("[dbo].[Ids]")
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<bool> DesasignarAsync(string idEscalador)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<bool>("DesasignarSherpa", new { IdEscalador = idEscalador },
                    commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.FirstOrDefault();
        }

        public async Task<ParticipanteEntity> GetByIdAsync(string id)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<ParticipanteEntity>("GetParticipantes",
            new
            {
                IdNivel = default(int?),
                IdLineaCarrera = default(int?),
                IdParticipante = id,
                Rol = default(int?),
                Search = default(string),
                IdSede = default(int?)
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ParticipanteEntity>> GetEscaladoresNoAsignadosAsync(int idLineaCarrera, int? idSede, string search)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<ParticipanteEntity>("GetEscaladoresNoAsignados",
            new
            {
                IdLineaCarrera = idLineaCarrera,
                Rol = (int)RolEnum.Escalador,
                IdSede = idSede,
                Search = search
            },
            commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<IEnumerable<ParticipanteEntity>> GetEscaladoresPorSherpaIdAsync(string id)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<ParticipanteEntity>("GetEscaladoresPorSherpa",
            new
            {
                IdSherpa = id,
                Rol = (int)RolEnum.Escalador
            },
            commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<IEnumerable<ParticipanteEntity>> GetSherpasAsync(int? idNivel, int? idLineaCarrera, int? idSede, string search)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<ParticipanteEntity>("GetParticipantes",
            new
            {
                IdNivel = idNivel,
                IdLineaCarrera = idLineaCarrera,
                IdParticipante = default(int?),
                Rol = (int)RolEnum.Sherpa,
                Search = search,
                IdSede = idSede
            },
            commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<IEnumerable<ParticipanteEntity>> GetParticipantesAsync(int? idLineaCarrera, int? idNivel)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<ParticipanteEntity>("GetParticipantes",
            new
            {
                IdNivel = idNivel,
                IdLineaCarrera = idLineaCarrera,
                IdParticipante = default(int?),
                Rol = default(int?),
                Search = default(string),
                IdSede = default(int?)
            },
            commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<int> CreateAsync(ParticipanteEntity participanteEntity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("CreateParticipante",
            new
            {
                participanteEntity.Nombre,
                participanteEntity.Apellido,
                participanteEntity.Correo,
                participanteEntity.Genero,
                participanteEntity.FechaNacimiento,
                participanteEntity.AñosExperiencia,
                participanteEntity.Calificacion,
                participanteEntity.Puntaje,
                participanteEntity.Photo,
                participanteEntity.IdSede,
                participanteEntity.IdSherpa,
                participanteEntity.IdLineaCarrera,
                participanteEntity.IdNivel
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ParticipanteEntity>> GetAllAsync()
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<ParticipanteEntity>("GetParticipantes",
            new
            {
                IdNivel = default(int?),
                IdLineaCarrera = default(int?),
                IdParticipante = default(int?),
                Rol = default(int?),
                Search = default(string),
                IdSede = default(int?)
            },
            commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<bool> DesasignacionAutomatica()
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<bool>("DesasignarSherpaAutomaticamente", commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("DeleteParticipante", new
            {
                IdParticipante = id
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault() > default(int);
        }

        public async Task<bool> ActualizarPuntajeAsync(string id, int puntaje)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<bool>("ActualizarPuntaje", new { Id = id, Puntaje = puntaje },
            commandType: CommandType.StoredProcedure);
            _dbConnection.Close();
            return result.FirstOrDefault();
        }
    }
}

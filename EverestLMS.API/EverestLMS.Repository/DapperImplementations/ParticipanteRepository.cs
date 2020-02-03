﻿using Dapper;
using EverestLMS.Common.Enums;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class ParticipanteRepository : BaseConnection, IParticipanteRepository
    {
        private readonly ILogger<ParticipanteRepository> logger;

        public ParticipanteRepository(IDbConnection dbConnection, ILogger<ParticipanteRepository> logger) : base(dbConnection)
        {
            this.logger = logger;
        }
        public async Task<bool> AsignarAsync(int idEscalador, int idSherpa)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<bool>("AsignarSherpa", new { IdEscalador = idEscalador, IdSherpa = idSherpa },
                    commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }    
        }

        public async Task<bool> AsignarAutomaticamenteAsync(int idSherpa, int[] idsEscaladores)
        {
            try
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("IdEscaladores", typeof(int));
                if (idsEscaladores != null)
                    idsEscaladores.ToList().ForEach(item => dataTable.Rows.Add(item));
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<bool>("AsignarAutomaticamente", new
                {
                    IdSherpa = idSherpa,
                    IdEscaladores = dataTable.AsTableValuedParameter("[dbo].[Ids]")
                },
                    commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }    
        }

        public async Task<bool> DesasignarAsync(int idEscalador)
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<bool>("DesasignarSherpa", new { IdEscalador = idEscalador },
                    commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }           
        }

        public async Task<ParticipanteEntity> GetByIdAsync(int id)
        {
            try
            {
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
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }          
        }

        public async Task<IEnumerable<ParticipanteEntity>> GetEscaladoresNoAsignadosAsync(int idLineaCarrera, int? idSede = null, string search = null)
        {
            try
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
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }          
        }

        public async Task<IEnumerable<ParticipanteEntity>> GetEscaladoresPorSherpaIdAsync(int id)
        {
            try
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
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }
            
        }

        public async Task<IEnumerable<ParticipanteEntity>> GetSherpasAsync(int? idNivel = null, int? idLineaCarrera = null, int? idSede = null, string search = null)
        {
            try
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
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }  
        }

        public async Task<IEnumerable<ParticipanteEntity>> GetParticipantesAsync(int? idLineaCarrera, int? idNivel)
        {
            try
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
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }           
        }

        public async Task<int> CreateAsync(ParticipanteEntity participanteEntity)
        {
            try
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
                        participanteEntity.Rol,
                        participanteEntity.Photo,
                        participanteEntity.IdSede,
                        participanteEntity.IdSherpa,
                        participanteEntity.IdLineaCarrera,
                        participanteEntity.IdNivel
                    },
                    commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }
            
        }

        public async Task<IEnumerable<ParticipanteEntity>> GetAllAsync()
        {
            try
            {
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
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }
        }

        public async Task<bool> DesasignacionAutomatica()
        {
            try
            {
                if (_dbConnection.State == ConnectionState.Closed)
                    _dbConnection.Open();
                var result = await _dbConnection.QueryAsync<bool>("DesasignarSherpaAutomaticamente", commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger?.LogError("An error ocurred with exception: {@Exception}", ex);
                return default;
            }
        }
    }
}
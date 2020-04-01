using Dapper;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class CursoRepository : BaseConnection, ICursoRepository
    {
        public CursoRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<int> CreateCursoAsync(CursoEntity cursoEntity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("CreateCurso",
            new
            {
                cursoEntity.Nombre,
                cursoEntity.Descripcion,
                cursoEntity.IdDificultad,
                cursoEntity.Idioma,
                cursoEntity.Imagen,
                cursoEntity.Puntaje,
                cursoEntity.IdEtapa,
                cursoEntity.Autor
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
            
        }

        public async Task<bool> DeleteCursoAsync(int idEtapa, int idCurso)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("DeleteCurso",
            new
            {
                IdEtapa = idEtapa,
                IdCurso = idCurso
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault() > default(int);
            
        }

        public async Task<bool> EditCursoASync(CursoEntity cursoEntity)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("EditCurso",
            new
            {
                cursoEntity.IdCurso,
                cursoEntity.Nombre,
                cursoEntity.Descripcion,
                cursoEntity.IdDificultad,
                cursoEntity.Idioma,
                cursoEntity.Imagen,
                cursoEntity.Puntaje,
                cursoEntity.IdEtapa,
                cursoEntity.Autor
            },
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault() > default(int);
        }

        public async Task<CursoToUpdateEntity> GetCursoAsync(int idEtapa, int idCurso)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<CursoToUpdateEntity>("GetCurso", new { IdEtapa = idEtapa, IdCurso = idCurso }, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<CursoDetalleEntity>> GetCursosAsync(int? idEtapa, int? idLineaCarrera, int? idNivel, string search)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<CursoDetalleEntity>("GetCursos", new { IdEtapa = idEtapa, IdNivel = idNivel, IdLineaCarrera = idLineaCarrera, Search = search }, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<IEnumerable<CursoEntity>> GetCursosByParticipanteAsync(string idParticipante, int? idEtapa = null, int? idIdioma = null)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<CursoPredictionEntity>("GetCursosByParticipante",
            new { Id = idParticipante, IdEtapa = idEtapa, IdIdioma = idIdioma }, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<IEnumerable<CursoPredictionEntity>> GetCursosPredictionByParticipanteAsync(string idParticipante, int? idEtapa = null, int? idIdioma = null)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<CursoPredictionEntity>("GetCursosPredictionByParticipante",
            new { Id = idParticipante, IdEtapa = idEtapa, IdIdioma = idIdioma }, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}

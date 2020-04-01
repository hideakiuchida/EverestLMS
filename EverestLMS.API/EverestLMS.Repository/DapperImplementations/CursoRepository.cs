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
            using (var conn = _dbConnection)
            {
                conn.Open();
                var result = await conn.QueryAsync<int>("CreateCurso",
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
        }

        public async Task<bool> DeleteCursoAsync(int idEtapa, int idCurso)
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                var result = await conn.QueryAsync<int>("DeleteCurso",
                new
                {
                    IdEtapa = idEtapa,
                    IdCurso = idCurso
                },
                commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault() > default(int);
            }
        }

        public async Task<bool> EditCursoASync(CursoEntity cursoEntity)
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                var result = await conn.QueryAsync<int>("EditCurso",
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
        }

        public async Task<CursoToUpdateEntity> GetCursoAsync(int idEtapa, int idCurso)
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                var result = await conn.QueryAsync<CursoToUpdateEntity>("GetCurso", new { IdEtapa = idEtapa, IdCurso = idCurso }, commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<CursoDetalleEntity>> GetCursosAsync(int? idEtapa, int? idLineaCarrera, int? idNivel, string search)
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                var result = await conn.QueryAsync<CursoDetalleEntity>("GetCursos", new { IdEtapa = idEtapa, IdNivel = idNivel, IdLineaCarrera = idLineaCarrera, Search = search }, commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.ToList();
            }
        }

        public async Task<IEnumerable<CursoEntity>> GetCursosByParticipanteAsync(string idParticipante, int? idEtapa = null, int? idIdioma = null)
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                var result = await conn.QueryAsync<CursoPredictionEntity>("GetCursosByParticipante",
                new { Id = idParticipante, IdEtapa = idEtapa, IdIdioma = idIdioma }, commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.ToList();
            }
        }

        public async Task<IEnumerable<CursoPredictionEntity>> GetCursosPredictionByParticipanteAsync(string idParticipante, int? idEtapa = null, int? idIdioma = null)
        {
            using (var conn = _dbConnection)
            {
                conn.Open();
                var result = await conn.QueryAsync<CursoPredictionEntity>("GetCursosPredictionByParticipante",
                new { Id = idParticipante, IdEtapa = idEtapa, IdIdioma = idIdioma }, commandType: CommandType.StoredProcedure);
                _dbConnection.Close();
                return result.ToList();
            }
        }
    }
}

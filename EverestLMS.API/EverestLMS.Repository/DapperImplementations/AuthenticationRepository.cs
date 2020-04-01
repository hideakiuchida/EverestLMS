using Dapper;
using EverestLMS.Common.Extensions;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EverestLMS.Repository.DapperImplementations
{
    public class AuthenticationRepository : BaseConnection, IAuthenticationRepository
    {
        public AuthenticationRepository(IDbConnection dbConnection) : base(dbConnection)
        {

        }

        public async Task<UsuarioEntity> GetUsuarioByUsername(string username)
        {
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<UsuarioEntity>("GetUsuarioByUsername",
                new
                {
                    username
                },
                commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
        }

        public async Task<int> Register(UsuarioEntity usuarioEntity, string password)
        {
            password.CreatePasswordHash(out byte[] passwordSalt, out byte[] passwordHash);
            usuarioEntity.PasswordSalt = passwordSalt;
            usuarioEntity.PasswordHash = passwordHash;
            usuarioEntity.UsuarioKey = Guid.NewGuid().ToString();
            if (_dbConnection.State == ConnectionState.Closed)
                _dbConnection.Open();
            var result = await _dbConnection.QueryAsync<int>("CreateUsuario",
                 new
                 {
                     usuarioEntity.UsuarioKey,
                     usuarioEntity.Username,
                     usuarioEntity.PasswordSalt,
                     usuarioEntity.PasswordHash,
                     usuarioEntity.IdRol,
                     usuarioEntity.IdParticipante
                 },
                 commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
        }

        public async Task<bool> UserExists(string username)
        {
            return await GetUsuarioByUsername(username) != null;
        }
    }
}

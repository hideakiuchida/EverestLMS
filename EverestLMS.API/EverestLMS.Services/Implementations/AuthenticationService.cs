using AutoMapper;
using EverestLMS.Common.Extensions;
using EverestLMS.Entities.Models;
using EverestLMS.Repository.Interfaces;
using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Authentication;
using System;
using System.Threading.Tasks;

namespace EverestLMS.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository repository;
        private readonly IParticipanteService participanteService;
        private readonly IMapper mapper;
        public AuthenticationService(IAuthenticationRepository repository, IParticipanteService participanteService, IMapper mapper)
        {
            this.repository = repository;
            this.participanteService = participanteService;
            this.mapper = mapper;
        }

        public async Task<UsuarioVM> Login(string username, string password)
        {
            var usuario = await repository.GetUsuarioByUsername(username);
            if (usuario == null) return default;
            var success = password.VerifyPasswordHash(usuario.PasswordSalt, usuario.PasswordHash);
            if (success)
                return mapper.Map<UsuarioVM>(usuario);
            else
                return default;

        }

        public async Task<int> Register(UsuarioToRegisterVM usuarioToRegisterVM)
        {
            usuarioToRegisterVM.Username = usuarioToRegisterVM.Username.ToLower();
            if (await repository.UserExists(usuarioToRegisterVM.Username))
                return int.MinValue;
            var usuarioToRegister = mapper.Map<UsuarioEntity>(usuarioToRegisterVM);

            var participanteId = await participanteService.CreateAsync(usuarioToRegisterVM.Participante);
            usuarioToRegister.IdParticipante = participanteId;
            try
            {
                var usuarioId = await repository.Register(usuarioToRegister, usuarioToRegisterVM.Password);
                return usuarioId;
            }
            catch (Exception)
            {
                await participanteService.DeleteAsync(participanteId);
                throw;
            }
            
        }
    }
}

using EverestLMS.Services.Interfaces;
using EverestLMS.ViewModels.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EverestLMS.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService service;
        private readonly IConfiguration configuration;
        public AuthController(IAuthenticationService service, IConfiguration configuration)
        {
            this.service = service;
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UsuarioToRegisterVM usuarioToRegisterVM)
        {
            var result = await service.Register(usuarioToRegisterVM);
            if (result == int.MinValue)
                return BadRequest("El usuario ya existe.");
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UsuarioForLoginVM usuarioForLoginVM)
        {
            var result = await service.Login(usuarioForLoginVM.Username.ToLower(), usuarioForLoginVM.Password);
            if (result == null)
                return Unauthorized();
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, result.UsuarioKey),
                new Claim(ClaimTypes.Name, result.Username),
                new Claim(ClaimTypes.Role, result.IdRol.ToString()),
                new Claim("puntaje", result.Puntaje.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token)});
        }

    }
}
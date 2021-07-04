using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Projeto_Roman.Domains;
using Projeto_Roman.Interfaces;
using Projeto_Roman.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Projeto_Roman.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IUsuarioRepository _usuario { get; set; }

        public LoginController()
        {
            _usuario = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login (Usuario login)
        {
            Usuario usuario = _usuario.Login(login.Email, login.Senha);

            if (usuario == null)
            {
                return NotFound("Email ou senha incorretos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuario.IdTipoUsuario.ToString()),
                new Claim("role", usuario.IdTipoUsuario.ToString()),
                new Claim("nome", usuario.Nome)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Roman-Authentication"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Roman",
                audience: "Roman",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}

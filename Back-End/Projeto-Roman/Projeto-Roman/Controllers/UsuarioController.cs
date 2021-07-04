using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Roman.Domains;
using Projeto_Roman.Interfaces;
using Projeto_Roman.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuario { get; set; }

        public UsuarioController()
        {
            _usuario = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuario.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);           
            }
            
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                _usuario.Cadastrar(usuario);

                return StatusCode(202);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _usuario.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
            
        }

        [HttpPut("NovaEquipe/{id}")]
        public IActionResult AddEquipe(int id, Usuario novaEquipe)
        {
            try
            {
                _usuario.NovaEquipe(id, novaEquipe);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}

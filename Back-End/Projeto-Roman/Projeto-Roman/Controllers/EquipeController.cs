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
    public class EquipeController : ControllerBase
    {
        private IEquipeRepository _projeto { get; set; }

        public EquipeController()
        {
            _projeto = new EquipeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_projeto.Listar());
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
                _projeto.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }

        [HttpPost]
        public IActionResult Cadastrar(Equipe equipe)
        {
            try
            {
                _projeto.Cadastrar(equipe);

                return StatusCode(202);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }

        }
    }
}

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
    public class ProjetoController : ControllerBase
    {
        private IProjetoRepository _projeto { get; set; }

        public ProjetoController()
        {
            _projeto = new ProjetoRepository();
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

        [HttpPost]
        public IActionResult Cadastrar(Projeto novoProjeto)
        {
            try
            {
                _projeto.Cadastrar(novoProjeto);

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
                _projeto.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult Editar(int id, Projeto att)
        {
            try
            {
                _projeto.Atualizar(id, att);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}

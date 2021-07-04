using Projeto_Roman.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.Interfaces
{
    interface IProjetoRepository
    {
        List<Projeto> Listar();
        List<Projeto> ListarAtivos();
        void Cadastrar(Projeto novoProjeto);
        void Deletar(int id);
        void Atualizar(int id, Projeto att);
        void Inativar(int id, Projeto inativar);
    }
}

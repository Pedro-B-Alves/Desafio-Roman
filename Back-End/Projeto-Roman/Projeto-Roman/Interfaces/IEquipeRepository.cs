using Projeto_Roman.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.Interfaces
{
    interface IEquipeRepository
    {
        List<Equipe> Listar();
        void Cadastrar(Equipe novaEquipe);
        void Deletar(int id);
        Equipe BuscarPeloId(int id);
    }
}

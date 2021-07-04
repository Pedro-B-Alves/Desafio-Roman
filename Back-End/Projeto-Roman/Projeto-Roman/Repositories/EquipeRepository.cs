using Projeto_Roman.Contexts;
using Projeto_Roman.Domains;
using Projeto_Roman.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.Repositories
{
    public class EquipeRepository : IEquipeRepository
    {
        Roman ctx = new Roman();

        public Equipe BuscarPeloId(int id)
        {
            return ctx.Equipes.Find(id);
        }

        public void Cadastrar(Equipe novaEquipe)
        {
            ctx.Equipes.Add(novaEquipe);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Equipe equipe = ctx.Equipes.Find(id);

            ctx.Equipes.Remove(equipe);

            ctx.SaveChanges();
        }

        public List<Equipe> Listar()
        {
            return ctx.Equipes.ToList();
        }
    }
}

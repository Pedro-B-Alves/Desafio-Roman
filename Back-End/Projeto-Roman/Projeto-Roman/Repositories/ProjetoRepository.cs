using System;
using System.Collections.Generic;
using Projeto_Roman.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Roman.Domains;
using Projeto_Roman.Contexts;

namespace Projeto_Roman.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        Roman ctx = new Roman();

        public void Atualizar(int id, Projeto att)
        {
            Projeto buscando = ctx.Projetos.Find(id);

            if (att.Tema != null)
            {
                buscando.Tema = att.Tema;
            }
            if (att.Projeto1 != null)
            {
                buscando.Projeto1 = att.Projeto1;
            }
            if (att.Descricao != null)
            {
                buscando.Descricao = att.Descricao;
            }

            ctx.Projetos.Update(buscando);

            ctx.SaveChanges();
        }

        public void Cadastrar(Projeto novoProjeto)
        {
            ctx.Projetos.Add(novoProjeto);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Projeto projeto = ctx.Projetos.Find(id);

            ctx.Projetos.Remove(projeto);

            ctx.SaveChanges();
        }

        public void Inativar(int id, Projeto inativar)
        {
            Projeto buscando = ctx.Projetos.Find(id);

            if (inativar.IdAtividade < 0)
            {
                buscando.IdAtividade = inativar.IdAtividade;
            }

            ctx.Projetos.Update(buscando);

            ctx.SaveChanges();
        }

        public List<Projeto> Listar()
        {
            return ctx.Projetos.ToList();
        }

        public List<Projeto> ListarAtivos()
        {
            return ctx.Projetos.Where(P => P.IdAtividade == 1).ToList();
        }
    }
}

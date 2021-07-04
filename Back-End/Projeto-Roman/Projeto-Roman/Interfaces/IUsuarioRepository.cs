using Projeto_Roman.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Roman.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar(); 
        void Cadastrar(Usuario novoUsuario); 
        void Deletar(int id);
        Usuario Login(string email, string senha);
        void NovaEquipe(int id, Usuario novaEquipe);
    }
}

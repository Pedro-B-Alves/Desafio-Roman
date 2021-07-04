using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Roman.Domains
{
    public partial class Projeto
    {
        public int IdProjeto { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdAtividade { get; set; }
        public string Tema { get; set; }
        public string Projeto1 { get; set; }
        public string Descricao { get; set; }

        public virtual Atividade IdAtividadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Projeto_Roman.Domains
{
    public partial class Atividade
    {
        public Atividade()
        {
            Projetos = new HashSet<Projeto>();
        }

        public int IdAtividade { get; set; }
        public string Atividade1 { get; set; }

        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}

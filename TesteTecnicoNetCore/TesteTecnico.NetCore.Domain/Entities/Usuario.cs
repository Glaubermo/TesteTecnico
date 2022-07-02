using System;
using TesteTecnico.NetCore.Domain.Entities.Base;

namespace TesteTecnico.NetCore.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }


        public int EcolaridadeId { get; set; }
        public virtual Escolaridade Ecolaridade { get; set; }

        public int HistoricoEScolarId { get; set; }
        public virtual HistoricoEscolar HistoricoEscolar { get; set; }
    }
}

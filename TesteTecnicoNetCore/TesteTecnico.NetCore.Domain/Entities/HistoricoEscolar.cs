using System.Collections.Generic;
using TesteTecnico.NetCore.Domain.Entities.Base;

namespace TesteTecnico.NetCore.Domain.Entities
{
    public class HistoricoEscolar : EntityBase
    {
        public string Formato { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }  
    }
}

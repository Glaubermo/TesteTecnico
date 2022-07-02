﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.Entities.Base;

namespace TesteTecnico.NetCore.Domain.Entities
{
    public class Escolaridade : EntityBase
    {
        public string Descricao { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.Entities;

namespace TesteTecnico.NetCore.Data.Mapping
{
    public class EscolaridadeMap : IEntityTypeConfiguration<Escolaridade>
    {
        public void Configure(EntityTypeBuilder<Escolaridade> builder)
        {
            builder.ToTable("Escolaridade");

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(11)")
                .HasColumnName("Descricao");

        }
    }
}

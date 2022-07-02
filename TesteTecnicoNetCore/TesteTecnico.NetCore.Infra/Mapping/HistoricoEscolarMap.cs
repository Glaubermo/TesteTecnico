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
    public class HistoricoEscolarMap : IEntityTypeConfiguration<HistoricoEscolar>
    {
        public void Configure(EntityTypeBuilder<HistoricoEscolar> builder)
        {
            builder.ToTable("HistoricoEscolar");

            builder.Property(x => x.Formato)
                .IsRequired()
                .HasColumnType("varchar(3)")
                .HasColumnName("Formato");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(55)")
                .HasColumnName("Nome");
        }
    }
}

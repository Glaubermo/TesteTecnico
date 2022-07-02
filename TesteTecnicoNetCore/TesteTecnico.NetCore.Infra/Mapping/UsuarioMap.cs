using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteTecnico.NetCore.Domain.Entities;

namespace TesteTecnico.NetCore.Infra.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(60)")
                .HasColumnName("Nome");

            builder.Property(x => x.SobreNome)
                .IsRequired()
                .HasColumnType("varchar(80)")
                .HasColumnName("SobreNome");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasColumnName("Email");

            builder.Property(x => x.DataNascimento)
                .IsRequired()
                .HasColumnType("date")
                .HasColumnName("DataNascimento");

            builder.HasOne(e => e.Ecolaridade)
                .WithMany(u => u.Usuarios)
                .HasForeignKey(fk => fk.EcolaridadeId)
                .HasPrincipalKey(fk => fk.Id);

            builder.HasOne(h => h.HistoricoEscolar)
                .WithMany(u => u.Usuarios)
                .HasForeignKey(fk => fk.HistoricoEScolarId)
                .HasPrincipalKey(fk => fk.Id);

        }
    }
}

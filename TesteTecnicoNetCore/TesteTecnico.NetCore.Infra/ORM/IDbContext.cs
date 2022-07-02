using Microsoft.EntityFrameworkCore;
using System.Linq;
using TesteTecnico.NetCore.Domain.Entities;

namespace TesteTecnico.NetCore.Infra.ORM
{
    public class IDbContext : DbContext 
    {
        public IDbContext(DbContextOptions<IDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }        
        public DbSet<Escolaridade> Escolaridade { get; set; }        
        public DbSet<HistoricoEscolar> HistoricoEscolar { get; set; }        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
            {
                //property.Relational().ColumnType = "varchar(90)";
                property.SetColumnType("varchar(90)");
            }

            // Busca os Mapppings de uma vez só
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IDbContext).Assembly);

            //remover delete cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);

        }
    }
}
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Data.Repository.Base;
using TesteTecnico.NetCore.Domain.Entities;
using TesteTecnico.NetCore.Domain.Interfaces.Repository;
using TesteTecnico.NetCore.Infra.ORM;

namespace TesteTecnico.NetCore.Data.Repository
{
    public class HistoricoEscolarRepository : GenericRepository<HistoricoEscolar, int>, IHistoricoEscolarRepository
    {
        public HistoricoEscolarRepository(IDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HistoricoEscolar>> ListaHistoricoEscolar()
        {
          return await _context.HistoricoEscolar.AsNoTracking().ToArrayAsync();
        }

        public async Task<HistoricoEscolar> ListaHistoricoEscolarPorId(int historicoEscolarId)
        {
            return await _context.HistoricoEscolar.FirstOrDefaultAsync(x => x.Id == historicoEscolarId);
        }
    }
}

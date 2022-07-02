using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Data.Repository.Base;
using TesteTecnico.NetCore.Domain.Entities;
using TesteTecnico.NetCore.Domain.Interfaces.Repository;
using TesteTecnico.NetCore.Infra.ORM;

namespace TesteTecnico.NetCore.Data.Repository
{
    public class EscolaridadeRepository : GenericRepository<Escolaridade, int>, IEscolaridadeRepository
    {
        public EscolaridadeRepository(IDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Escolaridade> ListaEscolaridadesPorId(int escolaridadeId)
        {
            return await _context.Escolaridade.FirstOrDefaultAsync(x => x.Id == escolaridadeId);
        }

        public async Task<IEnumerable<Escolaridade>> ListaTodasEscolaridades()
        {
            return await _context.Escolaridade.AsNoTracking().ToArrayAsync();
        }
    }
}

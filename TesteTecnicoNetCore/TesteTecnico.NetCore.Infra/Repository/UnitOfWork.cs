using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.Interfaces.Repository;
using TesteTecnico.NetCore.Infra.ORM;

namespace TesteTecnico.NetCore.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            var success = (await _context.SaveChangesAsync()) > 0;
            return success;
        }

        public Task Rollback()
        {
            return  Task.CompletedTask;
        }
    }
}

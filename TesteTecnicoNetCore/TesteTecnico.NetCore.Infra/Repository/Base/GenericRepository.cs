using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.Entities.Base;
using TesteTecnico.NetCore.DomainCore.Base;
using TesteTecnico.NetCore.Infra.ORM;

namespace TesteTecnico.NetCore.Data.Repository.Base
{
    public abstract class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : EntityBase, new()
    {

        protected IDbContext _context;

        public GenericRepository(IDbContext ctx)
        {
            this._context = ctx;
        }

        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> when = null)
        {
            if (when == null)
            {
                return await this._context.Set<T>().AsNoTracking().ToListAsync();
            }
            return await this._context.Set<T>().AsNoTracking().Where(when).ToListAsync();
        }

        public async Task<T> GetById(TKey id)
        {
            return await this._context.Set<T>().FindAsync(id);
        }

        public virtual async Task Add(T obj)
        {
            this._context.Set<T>().Add(obj);
            await SaveAsync();
        }

        public virtual async Task Update(T obj)
        {
            this._context.Entry(obj).State = EntityState.Modified;
            await SaveAsync();
        }

        public virtual async Task Delete(T obj)
        {
            this._context.Entry(obj).State = EntityState.Deleted;
            await SaveAsync();
        }

        public virtual async Task DeleteById(TKey id)
        {
            T obj = await GetById(id);
            await Delete(obj);
        }

        public virtual async Task<int> SaveAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TesteTecnico.NetCore.DomainCore.Base
{
    public interface IGenericRepository<T, TKey> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> when = null);
        Task<T> GetById(TKey id);
        Task Add(T obj);
        Task Update(T obj);
        Task Delete(T obj);
        Task DeleteById(TKey id);
    }
}

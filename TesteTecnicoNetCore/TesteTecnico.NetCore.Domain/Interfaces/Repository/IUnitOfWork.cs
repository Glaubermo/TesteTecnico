using System.Threading.Tasks;

namespace TesteTecnico.NetCore.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        Task Rollback();    
    }
}

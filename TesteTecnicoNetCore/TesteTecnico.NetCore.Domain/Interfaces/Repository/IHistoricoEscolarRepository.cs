using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.Entities;
using TesteTecnico.NetCore.DomainCore.Base;

namespace TesteTecnico.NetCore.Domain.Interfaces.Repository
{
    public interface IHistoricoEscolarRepository : IGenericRepository<HistoricoEscolar, int>
    {
        Task<IEnumerable<HistoricoEscolar>> ListaHistoricoEscolar();
        Task<HistoricoEscolar> ListaHistoricoEscolarPorId(int historicoEscolarId);
    }
}

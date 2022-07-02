using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.Entities;
using TesteTecnico.NetCore.DomainCore.Base;

namespace TesteTecnico.NetCore.Domain.Interfaces.Repository
{
    public interface IEscolaridadeRepository : IGenericRepository<Escolaridade, int>
    {
        Task<IEnumerable<Escolaridade>> ListaTodasEscolaridades();
        Task<Escolaridade> ListaEscolaridadesPorId(int escolaridadeId);
    }
}

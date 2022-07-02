using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.Entities;

namespace TesteTecnico.NetCore.Domain.Interfaces.Services
{
    public interface IHistoricoEscolarDomainService
    {
        Task AdicionarHistoricoEscolar(HistoricoEscolar historicoEscolar);
        Task AlterarHistoricoEscolar(HistoricoEscolar historicoEscolar);
        Task DeletarHistoricoEscolar(HistoricoEscolar historicoEscolar);
        Task DeletarHistoricoPorId(int Id);
        Task<IEnumerable<HistoricoEscolar>> ListaTodosHistoricoEscolar();
        Task<HistoricoEscolar> ListaHistoricoEscolarPorId(int historicoEscolarId);
    }
}

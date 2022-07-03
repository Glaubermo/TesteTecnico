using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.Entities;
using TesteTecnico.NetCore.Domain.Interfaces.Repository;
using TesteTecnico.NetCore.Domain.Interfaces.Services;

namespace TesteTecnico.NetCore.Domain.Services
{
    public class HistoricoEscolarDomainService : IHistoricoEscolarDomainService
    {
        private readonly IHistoricoEscolarRepository _repo;
        private readonly IUnitOfWork _uow;

        public HistoricoEscolarDomainService(IHistoricoEscolarRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task AdicionarHistoricoEscolar(HistoricoEscolar historicoEscolar)
        {
            await _repo.Add(historicoEscolar);
            await _uow.Commit();
        }

        public async Task AlterarHistoricoEscolar(HistoricoEscolar historicoEscolar)
        {
            await _repo.Update(historicoEscolar);
            await _uow.Commit();
        }

        public async Task DeletarHistoricoEscolar(HistoricoEscolar historicoEscolar)
        {
            await _repo.Delete(historicoEscolar);
            await _uow.Commit();
        }

        public async Task DeletarHistoricoPorId(int Id)
        {
            await _repo.DeleteById(Id);
            await _uow.Commit();
        }

        public async Task<IEnumerable<HistoricoEscolar>> ListaTodosHistoricoEscolar()
        {
           return await _repo.ListaHistoricoEscolar();    
        }

        public async Task<HistoricoEscolar> ListaHistoricoEscolarPorId(int historicoEscolarId)
        {
            return await _repo.ListaHistoricoEscolarPorId(historicoEscolarId);
        }


        public void Dispose()
        {
            _repo?.Dispose();
        }

        
    }
}

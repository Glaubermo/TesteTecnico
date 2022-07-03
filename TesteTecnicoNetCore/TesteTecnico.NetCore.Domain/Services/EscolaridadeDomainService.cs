using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.Entities;
using TesteTecnico.NetCore.Domain.Interfaces.Repository;
using TesteTecnico.NetCore.Domain.Interfaces.Services;

namespace TesteTecnico.NetCore.Domain.Services
{
    public class EscolaridadeDomainService : IEscolaridadeDomainService
    {
        private readonly IEscolaridadeRepository _repo;
        private readonly IUnitOfWork _uow;

        public EscolaridadeDomainService(IEscolaridadeRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }


        public async Task AdicionarEscolaridade(Escolaridade escolaridade)
        {
            await _repo.Add(escolaridade); 
            await _uow.Commit();
        }

        public async Task AlterarEscolaridade(Escolaridade escolaridade)
        {
            await _repo.Update(escolaridade);
            await _uow.Commit();
        }

        public async Task DeletarEscolaridade(Escolaridade escolaridade)
        {
            await _repo.Delete(escolaridade);
            await _uow.Commit();
        }

        public async Task DeletarEscolaridadePorId(int Id)
        {
            await _repo.DeleteById(Id);
            await _uow.Commit();
        }

        public async Task<Escolaridade> ListaEscolaridadePorId(int escolaridadeId)
        {
            return await _repo.ListaEscolaridadesPorId(escolaridadeId); 
        }

        public async Task<IEnumerable<Escolaridade>> ListaTodasEscolaridades()
        {
            return await _repo.ListaTodasEscolaridades();   
        }

        public void Dispose()
        {
            _repo?.Dispose();
        }
    }
}

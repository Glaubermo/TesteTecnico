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

        public EscolaridadeDomainService(IEscolaridadeRepository repo)
        {
            _repo = repo;
        }


        public async Task AdicionarEscolaridade(Escolaridade escolaridade)
        {
            await _repo.Add(escolaridade); 
        }

        public async Task AlterarEscolaridade(Escolaridade escolaridade)
        {
            await _repo.Update(escolaridade);
        }

        public async Task DeletarEscolaridade(Escolaridade escolaridade)
        {
            await _repo.Delete(escolaridade);   
        }

        public async Task DeletarEscolaridadePorId(int Id)
        {
            await _repo.DeleteById(Id);
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

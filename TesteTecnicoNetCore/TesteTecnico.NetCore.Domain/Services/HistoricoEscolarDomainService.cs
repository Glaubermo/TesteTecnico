﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.Entities;
using TesteTecnico.NetCore.Domain.Interfaces.Repository;
using TesteTecnico.NetCore.Domain.Interfaces.Services;

namespace TesteTecnico.NetCore.Domain.Services
{
    public class HistoricoEscolarDomainService : IHistoricoEscolarDomainService
    {
        private readonly IHistoricoEscolarRepository _repo;

        public HistoricoEscolarDomainService(IHistoricoEscolarRepository repo)
        {
            _repo = repo;
        }

        public async Task AdicionarHistoricoEscolar(HistoricoEscolar historicoEscolar)
        {
            await _repo.Add(historicoEscolar);
        }

        public async Task AlterarHistoricoEscolar(HistoricoEscolar historicoEscolar)
        {
            await _repo.Update(historicoEscolar);
        }

        public async Task DeletarHistoricoEscolar(HistoricoEscolar historicoEscolar)
        {
            await _repo.Delete(historicoEscolar);
        }

        public async Task DeletarHistoricoPorId(int Id)
        {
            await _repo.DeleteById(Id);
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

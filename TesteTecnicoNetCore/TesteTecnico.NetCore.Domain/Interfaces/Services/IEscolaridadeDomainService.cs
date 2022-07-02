using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.Entities;

namespace TesteTecnico.NetCore.Domain.Interfaces.Services
{
    public interface IEscolaridadeDomainService
    {
        Task AdicionarEscolaridade(Escolaridade escolaridade);
        Task AlterarEscolaridade(Escolaridade escolaridade);
        Task DeletarEscolaridade(Escolaridade escolaridade);
        Task DeletarEscolaridadePorId(int Id);
        Task<IEnumerable<Escolaridade>> ListaTodasEscolaridades();
        Task<Escolaridade> ListaEscolaridadePorId(int escolaridadeId);
    }
}

using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.DTO;
using TesteTecnico.NetCore.Domain.Entities;

namespace TesteTecnico.NetCore.Domain.Services.Infra
{
    public interface IHistoricoEscolarPDF
    {
        Task<HistoricoEscolar> Salvar(HistoricoEscolarDTO historicoEscolarDTO);
        HistoricoEscolar GerarRelatorio(string nomeHistoricoEscola);
    }
}

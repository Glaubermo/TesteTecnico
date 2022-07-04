using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.Services.Infra;

namespace TesteTecnico.NetCore.Domain.Interfaces.Services
{
    public interface IArquivo
    {
        public byte[] GetFile(string filename);
        public Task<DetalheArquivo> SaveFileToDisk(IFormFile file);
    }
}

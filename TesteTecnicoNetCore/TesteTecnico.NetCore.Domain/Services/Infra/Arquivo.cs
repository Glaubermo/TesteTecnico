using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.Interfaces.Services;

namespace TesteTecnico.NetCore.Domain.Services.Infra
{
    public class Arquivo : IArquivo
    {
        private readonly string _basePath;
        private readonly IHttpContextAccessor _context;

        public Arquivo(IHttpContextAccessor context = null)
        {
            _basePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
            _context = context;
        }


        public byte[] GetFile(string filename)
        {
            var filePath = _basePath + filename;
            return File.ReadAllBytes(filePath);
        }              

        public async Task<DetalheArquivo> SaveFileToDisk(IFormFile file)
        {
            DetalheArquivo detalheArquivo = new DetalheArquivo();

            var fileType = Path.GetExtension(file.FileName);
            var baseUrl = _context.HttpContext.Request.Host;

            if (fileType.ToLower() == ".pdf" || fileType.ToLower() == ".doc")
            {
                var docName = Path.GetFileName(file.FileName);
                if (file != null && file.Length > 0)
                {
                    var destination = Path.Combine(_basePath, "", docName);
                    detalheArquivo.DocumentName = docName;
                    detalheArquivo.DocType = fileType;
                    detalheArquivo.DocUrl = Path.Combine(baseUrl + "/api/file/" + detalheArquivo.DocumentName);

                    using var stream = new FileStream(destination, FileMode.Create);
                    await file.CopyToAsync(stream);
                }
            }
            return detalheArquivo;
        }     

    }
}

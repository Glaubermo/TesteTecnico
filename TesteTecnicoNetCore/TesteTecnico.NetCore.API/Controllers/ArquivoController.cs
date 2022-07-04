using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.Interfaces.Services;
using TesteTecnico.NetCore.Domain.Services.Infra;

namespace TesteTecnico.NetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivoController : ControllerBase
    {
        private readonly IArquivo _arquivo;
        public ArquivoController(IArquivo arquivo)
        {
            _arquivo = arquivo;
        }

        [HttpGet("downloadArquivo/{fileName}")]
        public async Task<IActionResult> GetFileAsync(string fileName)
        {
            byte[] buffer = _arquivo.GetFile(fileName);
            if (buffer != null)
            {
                HttpContext.Response.ContentType =
                    $"application/{Path.GetExtension(fileName).Replace(".", "")}";
                HttpContext.Response.Headers.Add("content-length", buffer.Length.ToString());
                await HttpContext.Response.Body.WriteAsync(buffer, 0, buffer.Length);
            }
            return new ContentResult();
        }

        [HttpPost("uploadArquivo")]
        public async Task<IActionResult> UploadArquivo([FromForm] IFormFile file)
        {
            DetalheArquivo detail = await _arquivo.SaveFileToDisk(file);
            return new OkObjectResult(detail);
        }      


    }
}

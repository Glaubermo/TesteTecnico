using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.NetCore.API.ServiceApp.DTO;
using TesteTecnico.NetCore.API.ServiceApp.Validation;
using TesteTecnico.NetCore.Domain.Entities;
using TesteTecnico.NetCore.Domain.Interfaces.Services;

namespace TesteTecnico.NetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaridadeController : ControllerBase
    {
        private readonly IEscolaridadeDomainService _escolaridadeDomainService;
        private readonly IMapper _mapper;

        public EscolaridadeController(IEscolaridadeDomainService escolaridadeDomainService, IMapper mapper)
        {
            _escolaridadeDomainService = escolaridadeDomainService;
            _mapper = mapper;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var escolaridade = await _escolaridadeDomainService.ListaEscolaridadePorId(id);
            if (escolaridade == null) return NotFound();
            return Ok(escolaridade);
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var escolaridade = await _escolaridadeDomainService.ListaTodasEscolaridades();
            if (escolaridade == null) return NotFound();          

            return Ok(escolaridade);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EscolaridadeDTO escolaridadeDTO)
        {
            if (escolaridadeDTO == null) return BadRequest();            

            var tipoEscolaridade = _mapper.Map<Escolaridade>(escolaridadeDTO);

            var validator = new EscolaridadeValidation();

            var results = validator.Validate(escolaridadeDTO);

            if (results.IsValid == false)
            {
                return BadRequest(new { Error = results.Errors });
            }

            await _escolaridadeDomainService.AdicionarEscolaridade(tipoEscolaridade); 

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EscolaridadeDTO escolaridadeDTO)
        {
            if (escolaridadeDTO == null) return BadRequest();

            var tipoEscolaridade = _mapper.Map<Escolaridade>(escolaridadeDTO);

            var validator = new EscolaridadeValidation();

            var results = validator.Validate(escolaridadeDTO);

            if (results.IsValid == false)
            {
                await _escolaridadeDomainService.AlterarEscolaridade(tipoEscolaridade);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _escolaridadeDomainService.DeletarEscolaridadePorId(id);

            return Ok();
        }
    }
}

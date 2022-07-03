using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.NetCore.API.ServiceApp.DTO;
using TesteTecnico.NetCore.Domain.Entities;
using TesteTecnico.NetCore.Domain.Interfaces.Services;

namespace TesteTecnico.NetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoEscolarController : ControllerBase
    {
        private readonly IHistoricoEscolarDomainService _historicoEscolarDomainService;
        private readonly IMapper _mapper;

        public HistoricoEscolarController(IHistoricoEscolarDomainService historicoEscolarDomainService, IMapper mapper)
        {
            _historicoEscolarDomainService = historicoEscolarDomainService;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var historicoEscolar = _mapper.Map<HistoricoEscolarDTO>(await _historicoEscolarDomainService.ListaHistoricoEscolarPorId(id));
            if (historicoEscolar == null) return NotFound();
            return Ok(historicoEscolar);
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var historicoEscolar = _mapper.Map<IEnumerable<HistoricoEscolarDTO>>(await _historicoEscolarDomainService.ListaTodosHistoricoEscolar());
            if (historicoEscolar == null) return NotFound();

            return Ok(historicoEscolar);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HistoricoEscolarDTO historicoEscolarDTO)
        {
            if (historicoEscolarDTO == null) return BadRequest();

            await _historicoEscolarDomainService.AdicionarHistoricoEscolar(_mapper.Map<HistoricoEscolar>(historicoEscolarDTO));

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] HistoricoEscolarDTO historicoEscolarDTO)
        {
            if (historicoEscolarDTO == null) return BadRequest();

            await _historicoEscolarDomainService.AlterarHistoricoEscolar(_mapper.Map<HistoricoEscolar>(historicoEscolarDTO));

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _historicoEscolarDomainService.DeletarHistoricoPorId(id);

            return Ok();
        }


    }
}

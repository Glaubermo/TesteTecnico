using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioDomainService _usuarioDomainService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioDomainService usuarioDomainService, IMapper mapper)
        {
            _usuarioDomainService = usuarioDomainService;
            _mapper = mapper;
        }


        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var usuarios = _mapper.Map<IEnumerable<UsuarioDTO>>(await _usuarioDomainService.ListaTodosUsuario());
            if (usuarios == null) return NotFound();

            return Ok(usuarios);
        }

        [HttpGet("Escolaridade/{id}")]
        public async Task<IActionResult> UsuarioComEscolaridade(int id)
        {
            var usuarios = _mapper.Map<UsuarioEscolaridadeDTO>(await _usuarioDomainService.UsuarioComEscolaridade(id));
            if (usuarios == null) return NotFound();

            return Ok(usuarios);
        }

        [HttpGet("EscolaridadeHistoricoEscolar/{id}")]
        public async Task<IActionResult> UsuarioComEscolaridadeEHistoricoEscolar(int id)
        {
            var usuarios = _mapper.Map<UsuarioEscolaridadeHistoricoEscolarDTO>(await _usuarioDomainService.UsuarioComEscolaridadeEHistoricoEscolar(id));
            if (usuarios == null) return NotFound();

            return Ok(usuarios);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null) return BadRequest();

            var validator = new UsuarioValidation();

            var results = validator.Validate(usuarioDTO);

            if (results.IsValid == false)
            {
                return BadRequest(new { Error = results.Errors});
            }

            await _usuarioDomainService.AdicionarUsuario(_mapper.Map<Usuario>(usuarioDTO));

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null) return BadRequest();

            await _usuarioDomainService.AlterarUsuario(_mapper.Map<Usuario>(usuarioDTO));

            return Ok();
        }

    }
}
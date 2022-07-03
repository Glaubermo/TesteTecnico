using System;

namespace TesteTecnico.NetCore.API.ServiceApp.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EcolaridadeId { get; set; }
        public int HistoricoEScolarId { get; set; }
    }
}

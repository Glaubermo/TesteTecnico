using System;

namespace TesteTecnico.NetCore.API.ServiceApp.DTO
{
    public class UsuarioEscolaridadeHistoricoEscolarDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual EscolaridadeDTO Ecolaridade { get; set; }
        public virtual HistoricoEscolarDTO HistoricoEscolar { get; set; }
    }
}

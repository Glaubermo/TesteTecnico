using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.Entities;
using TesteTecnico.NetCore.DomainCore.Base;

namespace TesteTecnico.NetCore.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IGenericRepository<Usuario, int>
    {
        Task<Usuario> ListaUsuarioPorId(int usuarioId);
        Task<IEnumerable<Usuario>> ListaTodosUsuario();
        Task<Usuario> UsuarioComEscolaridade(int usuarioId);
        Task<IEnumerable<Usuario>> UsuariosComEscolaridade(int escolaridadeId);
        Task<Usuario> HistoricoEscolarDoUsuario(int usuarioId);
        Task<Usuario> UsuarioComEscolaridadeEHistoricoEscolar(int usuarioId);
    }
}

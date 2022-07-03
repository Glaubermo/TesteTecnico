using System.Collections.Generic;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.Entities;

namespace TesteTecnico.NetCore.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService
    {
        Task AdicionarUsuario(Usuario usuario);
        Task AlterarUsuario(Usuario usuario);
        Task DeletarUsuario(Usuario usuario);
        Task DeletarUsuarioPorId(int usuarioId);

        Task<Usuario> ListaUsuarioPorId(int usuarioId);
        Task<IEnumerable<Usuario>> ListaTodosUsuario();
        Usuario UsuarioComEscolaridade(int usuarioId);
        Task<IEnumerable<Usuario>> UsuariosComEscolaridade(int escolaridadeId);
        Task<Usuario> HistoricoEscolarDoUsuario(int usuarioId);
        Usuario UsuarioComEscolaridadeEHistoricoEscolar(int usuarioId);
    }
}

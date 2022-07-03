using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.Entities;
using TesteTecnico.NetCore.Domain.Interfaces.Repository;
using TesteTecnico.NetCore.Domain.Interfaces.Services;

namespace TesteTecnico.NetCore.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUsuarioRepository _repo;
        private readonly IUnitOfWork _uow;

        public UsuarioDomainService(IUsuarioRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task AdicionarUsuario(Usuario usuario)
        {
            await _repo.Add(usuario); 
            await _uow.Commit();  
        }

        public async Task AlterarUsuario(Usuario usuario)
        {
            await _repo.Update(usuario);
            await _uow.Commit();
        }

        public async Task DeletarUsuario(Usuario usuario)
        {
            await _repo.Delete(usuario);
            await _uow.Commit();
        }

        public async Task DeletarUsuarioPorId(int usuarioId)
        {
            await _repo.DeleteById(usuarioId);
            await _uow.Commit();
        }


        public async Task<Usuario> HistoricoEscolarDoUsuario(int usuarioId)
        {
            return await _repo.HistoricoEscolarDoUsuario(usuarioId);
        }

        public async Task<IEnumerable<Usuario>> ListaTodosUsuario()
        {
           return await _repo.ListaTodosUsuario();
        }

        public async Task<Usuario> ListaUsuarioPorId(int usuarioId)
        {
            return await _repo.ListaUsuarioPorId(usuarioId);
        }

        public async Task<Usuario> UsuarioComEscolaridade(int usuarioId)
        {
            return await _repo.UsuarioComEscolaridade(usuarioId);
        }

        public async Task<Usuario> UsuarioComEscolaridadeEHistoricoEscolar(int usuarioId)
        {
            return await  _repo.UsuarioComEscolaridadeEHistoricoEscolar(usuarioId);
        }

        public async Task<IEnumerable<Usuario>> UsuariosComEscolaridade(int escolaridadeId)
        {
            return await _repo.UsuariosComEscolaridade(escolaridadeId);
        }
        public void Dispose()
        {
            _repo?.Dispose();
        }
    }
}

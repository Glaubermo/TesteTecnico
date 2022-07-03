using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Data.Repository.Base;
using TesteTecnico.NetCore.Domain.Entities;
using TesteTecnico.NetCore.Domain.Interfaces.Repository;
using TesteTecnico.NetCore.Infra.ORM;

namespace TesteTecnico.NetCore.Data.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario, int>, IUsuarioRepository
    {
        public UsuarioRepository(IDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> ListaUsuarioPorId(int usuarioId)
        {
            return await _context.Usuario.FirstOrDefaultAsync(x => x.Id == usuarioId);
        }

        public async Task<IEnumerable<Usuario>> ListaTodosUsuario()
        {
            return await _context.Usuario.AsNoTracking().ToArrayAsync();
        }

        public async Task<Usuario> UsuarioComEscolaridade(int usuarioId)
        {
            var query = await _context.Usuario
                .Include(e => e.Ecolaridade)
                .AsNoTracking()
                .Where(x => x.Id == usuarioId)
                .OrderBy(o => o.Nome)
                .FirstOrDefaultAsync();

            return query;
        }


        public async Task<IEnumerable<Usuario>> UsuariosComEscolaridade(int escolaridadeId)
        {
            return await _context.Usuario
                .Include(e => e.Ecolaridade)
                .AsNoTracking()
                .Where(x => x.Id == escolaridadeId)
                .OrderBy(o => o.Nome).ToListAsync();
        }


        public async Task<Usuario> HistoricoEscolarDoUsuario(int usuarioId)
        {
            return await _context.Usuario
                .Include(h => h.HistoricoEscolar)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == usuarioId);
        }


        //public Usuario UsuarioComEscolaridadeEHistoricoEscolar(int usuarioId)
        //{
        //    var query = from u in _context.Usuario
        //                join e in _context.Escolaridade on u.EcolaridadeId equals e.Id
        //                join h in _context.HistoricoEscolar on u.HistoricoEScolarId equals h.Id
        //                select new
        //                {
        //                    Id = u.Id,
        //                    Nome = u.Nome,
        //                    SobreNome = u.SobreNome,
        //                    Email = u.Email,
        //                    Escolaridade = e.Descricao,
        //                    HistoricoEscolar = h.Nome + "." + h.Formato

        //                };

        //    return (Usuario)query;
        //}

        public async Task<Usuario> UsuarioComEscolaridadeEHistoricoEscolar(int usuarioId)
        {
            var query = await _context.Usuario
                .Where(x => x.Id == usuarioId)
                .Include(x => x.Ecolaridade)
                .Include(x => x.HistoricoEscolar)
                .OrderBy(o => o.Nome)
                .FirstOrDefaultAsync(); 

            return query;
        }
    }
}

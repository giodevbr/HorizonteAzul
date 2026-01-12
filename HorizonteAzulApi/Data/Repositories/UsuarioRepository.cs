using HorizonteAzulApi.Data.Interfaces;
using HorizonteAzulApi.Data.Models.HorizonteAzul;
using Microsoft.EntityFrameworkCore;

namespace HorizonteAzulApi.Data.Repositories
{
    public class UsuarioRepository(HorizonteAzulContext context) : BaseRepository<Usuario>(context), IUsuarioRepository
    {
        public async Task<Usuario?> ObterPorIdAsync(int id)
        {
            return await _dbContext.Usuario.Include(t => t.TipoUsuario)
                                           .Include(t => t.SituacaoUsuario)
                                           .FirstOrDefaultAsync(x => x.UsuarioId == id);
        }

        public async Task<Usuario?> ObterPorEmailAsync(string email)
        {
            return await _dbContext.Usuario.Include(t => t.TipoUsuario)
                                           .Include(t => t.SituacaoUsuario)
                                           .FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}

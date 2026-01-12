using HorizonteAzulApi.Data.Models.HorizonteAzul;

namespace HorizonteAzulApi.Data.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario?> ObterPorIdAsync(int id);
        Task<Usuario?> ObterPorEmailAsync(string email);
    }
}

namespace HorizonteAzulApi.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<string?> AutenticarAsync(string email, string senha);
    }
}

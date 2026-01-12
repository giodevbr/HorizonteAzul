using HorizonteAzulApi.Data.Interfaces;
using HorizonteAzulApi.Data.Models.HorizonteAzul;
using HorizonteAzulApi.Domain.Interfaces;
using HorizonteAzulApi.Enums;
using HorizonteAzulApi.Extensions.Interfaces;
using HorizonteAzulApi.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HorizonteAzulApi.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly INotificadorDominio _notificadorDominio;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        private readonly string _jwtKey;

        public AuthService(IConfiguration configuration, INotificadorDominio notificadorDominio, IUsuarioRepository usuarioRepository)
        {
            _notificadorDominio = notificadorDominio;
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;

            _jwtKey = _configuration["Jwt:Key"] ?? throw new InvalidOperationException(StringResources.JwtKeyNaoConfigurado);
        }

        public async Task<string?> AutenticarAsync(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
                _notificadorDominio.AdicionarNotificacao(StringResources.EmailOuSenhaInvalidos);

            if (_notificadorDominio.VerificarOperacao())
            {
                var usuario = await _usuarioRepository.ObterPorEmailAsync(email);

                if (usuario == null)
                    _notificadorDominio.AdicionarNotificacao(StringResources.EmailOuSenhaInvalidos);

                if (_notificadorDominio.VerificarOperacao() && usuario != null)
                {
                    var hasher = new PasswordHasher<Usuario>();

                    if (hasher.VerifyHashedPassword(usuario, usuario.Senha, senha) == PasswordVerificationResult.Success)
                    {
                        if (usuario.SituacaoUsuarioId != ESituacaoUsuario.ATIVO.GetHashCode())
                            _notificadorDominio.AdicionarNotificacao(StringResources.UsuarioNaoEstaAtivo);
                        else
                            return GerarToken(usuario);
                    }
                    else
                    {
                        _notificadorDominio.AdicionarNotificacao(StringResources.EmailOuSenhaInvalidos);
                    }
                }
            }

            return null;
        }

        private string GerarToken(Usuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new Claim(JwtRegisteredClaimNames.Sub, usuario.Email),
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString()),
                    new Claim(ClaimTypes.Role, usuario.TipoUsuario.Descricao)
                ]),

                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

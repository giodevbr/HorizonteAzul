using HorizonteAzulApi.Domain.Interfaces;
using HorizonteAzulApi.Extensions;
using HorizonteAzulApi.Extensions.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HorizonteAzulApi.Controllers
{
    public class AuthController(INotificadorDominio notificadorDominio, IAuthService authService) : BaseController(notificadorDominio)
    {
        private readonly IAuthService _authService = authService;

        [HttpGet(Name = "Login")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(string email, string senha)
        {
            var retorno = await _authService.AutenticarAsync(email, senha);

            if (!_notificadorDominio.VerificarOperacao())
                return UnauthorizedResponse();

            return Ok(retorno);
        }
    }
}

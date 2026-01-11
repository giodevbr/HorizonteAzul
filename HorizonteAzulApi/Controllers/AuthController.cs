using HorizonteAzulApi.Domain.Dtos;
using HorizonteAzulApi.Extensions;
using HorizonteAzulApi.Extensions.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HorizonteAzulApi.Controllers
{

    public class AuthController(INotificadorDominio notificadorDominio) : BaseController(notificadorDominio)
    {
        [HttpGet(Name = "Login")]
        [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login()
        {
            return Ok("Login successful");
        }
    }
}

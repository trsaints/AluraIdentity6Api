using AluraIdentity6Api.Api.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace AluraIdentity6Api.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuariosController : ControllerBase
{
    [HttpPost]
    public IActionResult Cadastrar([FromBody] CreateUsuarioModel model)
    {
        throw new NotImplementedException();
    }
}

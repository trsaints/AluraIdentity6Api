using AluraIdentity6Api.Api.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace AluraIdentity6Api.Api.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult Cadastrar([FromBody] CreateUserModel model)
    {
        throw new NotImplementedException();
    }
}

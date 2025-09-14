using AluraIdentity6Api.Api.RequestModels;
using AluraIdentity6Api.App.Data.Models;
using AluraIdentity6Api.App.Services.Interfaces;
using AluraIdentity6Api.Infra.Data.Mappers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AluraIdentity6Api.Api.Controllers;

[ApiController]
[Route("[Controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly IMapper<AppUser, CreateUserModel> _mapper;
    private readonly IUserService _service;

    public UsersController(ILogger<UsersController> logger,
        IMapper<AppUser, CreateUserModel> mapper,
        IUserService service)
    {
        _logger = logger;
        _mapper = mapper;
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateUserModel model)
    {
        var mappedUser = _mapper.ToDomainModel(model);

        if (mappedUser is null) return BadRequest();

        var result = await _service.CreateAsync(mappedUser, model.Password!);

        if (!result.Succeeded) return BadRequest(result.Errors);

        var dto = _mapper.ToRequestModel(mappedUser);

        return Created($"/users/{mappedUser.Id}", dto);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserModel model)
    {
        var result = await _service.LoginAsync(model.Email!, model.Password!);

        if (!result.Succeeded) return BadRequest(result.Errors);

        var dto = _mapper.ToRequestModel(result.Data!);

        return Ok(dto);
    }
}

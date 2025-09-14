using System.ComponentModel.DataAnnotations;

namespace AluraIdentity6Api.Api.RequestModels;

public record LoginUserModel
{
    [Required]
    public required string Email { get; init; }

    [Required]
    public required string Password { get; init; }
}

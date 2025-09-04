using System.ComponentModel.DataAnnotations;

namespace AluraIdentity6Api.Api.RequestModels;

public record CreateUsuarioModel
{
    [Required]
    public string? UserName { get; init; }

    [Required]
    public DateTime DataNascimento { get; init; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; init; }

    [Required]
    [Compare(nameof(Password))]
    public string? ConfirmPassword { get; init; }
}

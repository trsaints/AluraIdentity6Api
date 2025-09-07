using AluraIdentity6Api.App.Data.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AluraIdentity6Api.App.Data.Models;

[Index(nameof(Cpf), IsUnique = true)]
public class AppUser : IdentityUser<string>, ITrackable
{
    public required string Cpf { get; set; }
    public string? FullName { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }
}

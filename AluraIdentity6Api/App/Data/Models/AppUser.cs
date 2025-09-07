using AluraIdentity6Api.App.Data.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AluraIdentity6Api.App.Data.Models;

[Index(nameof(Cpf), IsUnique = true)]
public class AppUser : IdentityUser<string>, ITrackable
{
    public required string Cpf { get; set; }
    public string? FullName { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }
    public string? Name { 
        get => throw new NotImplementedException(); 
        set => throw new NotImplementedException(); 
    }
}

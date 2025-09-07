using AluraIdentity6Api.App.Data.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AluraIdentity6Api.App.Data.Models;

public class AppUser : IdentityUser<string>, ITrackable
{
    public string? Name { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }
}

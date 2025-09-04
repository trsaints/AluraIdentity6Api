using AluraIdentity6Api.App.Data.Models.Interfaces;

namespace AluraIdentity6Api.App.Data.Models;

public class AppUser : ITrackable
{
    public string? Name { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }
}

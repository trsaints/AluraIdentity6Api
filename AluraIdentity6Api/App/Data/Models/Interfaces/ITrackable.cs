namespace AluraIdentity6Api.App.Data.Models.Interfaces;

public interface ITrackable
{
    public string? Name { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }
}

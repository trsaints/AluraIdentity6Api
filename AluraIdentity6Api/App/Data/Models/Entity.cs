using AluraIdentity6Api.App.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AluraIdentity6Api.App.Data.Models;

public abstract class Entity : ITrackable
{
    [Key]
    public int Id { get; set; }
    public virtual string? Name { get ; set ; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }
}

using AluraIdentity6Api.App.Data.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AluraIdentity6Api.App.Data.Models;

[Index(nameof(Cpf), IsUnique = true)]
public class AppUser : IdentityUser<int>, ITrackable
{
    [Required]
    [ProtectedPersonalData]
    [StringLength(11)]
    public required string Cpf { get; set; }

    [Required]
    [ProtectedPersonalData]
    public string? FullName { get; set; }

    [Required]
    [ProtectedPersonalData]
    public DateTime? BirthDate { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }

    [NotMapped]
    public string? Name { 
        get => throw new InvalidOperationException($"Use {nameof(FullName)}'s getter instead."); 
        set => throw new InvalidOperationException($"Use {nameof(FullName)}'s setter instead."); 
    }
}

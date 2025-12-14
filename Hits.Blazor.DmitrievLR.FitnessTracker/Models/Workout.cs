using System.ComponentModel.DataAnnotations;
using Hits.Blazor.DmitrievLR.FitnessTracker.Data;

namespace Hits.Blazor.DmitrievLR.FitnessTracker.Models;

public class Workout
{
    public int Id { get; set; }

    public DateTime Date { get; set; } = DateTime.Today;

    [MaxLength(500)]
    public string? Comment { get; set; }

    // Связь с пользователем Identity
    [Required]
    public string UserId { get; set; } = string.Empty;

    public ApplicationUser? User { get; set; }

    public ICollection<WorkoutEntry> Entries { get; set; } = new List<WorkoutEntry>();
}

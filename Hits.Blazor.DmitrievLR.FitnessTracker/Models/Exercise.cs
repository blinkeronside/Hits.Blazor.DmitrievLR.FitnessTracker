using System.ComponentModel.DataAnnotations;

namespace Hits.Blazor.DmitrievLR.FitnessTracker.Models;

public enum ExerciseType
{
    Strength = 1,
    Cardio = 2
}

public class Exercise
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public ExerciseType Type { get; set; } = ExerciseType.Strength;

    [MaxLength(500)]
    public string? Description { get; set; }

    // Навигация
    public ICollection<WorkoutEntry> WorkoutEntries { get; set; } = new List<WorkoutEntry>();
}

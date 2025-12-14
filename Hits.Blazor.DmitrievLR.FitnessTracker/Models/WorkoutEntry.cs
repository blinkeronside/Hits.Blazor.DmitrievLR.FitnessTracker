using System.ComponentModel.DataAnnotations;

namespace Hits.Blazor.DmitrievLR.FitnessTracker.Models;

public class WorkoutEntry
{
    public int Id { get; set; }

    [Required]
    public int WorkoutId { get; set; }
    public Workout? Workout { get; set; }

    [Required]
    public int ExerciseId { get; set; }
    public Exercise? Exercise { get; set; }

    [Range(1, 50)]
    public int Sets { get; set; } = 3;

    [Range(1, 200)]
    public int Reps { get; set; } = 10;

    // Вес в кг. Для кардио можно оставлять 0.
    [Range(0, 500)]
    public decimal WeightKg { get; set; } = 0m;

    // Для кардио можно использовать DurationMinutes, а WeightKg игнорировать
    [Range(0, 600)]
    public int DurationMinutes { get; set; } = 0;

    public decimal Volume => Sets * Reps * WeightKg;
}

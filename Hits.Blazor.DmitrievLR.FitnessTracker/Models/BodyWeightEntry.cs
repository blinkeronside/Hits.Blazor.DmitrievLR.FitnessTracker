using System.ComponentModel.DataAnnotations;
using Hits.Blazor.DmitrievLR.FitnessTracker.Data;

namespace Hits.Blazor.DmitrievLR.FitnessTracker.Models;

public class BodyWeightEntry
{
    public int Id { get; set; }

    public DateTime Date { get; set; } = DateTime.Today;

    [Range(20, 400)]
    public decimal WeightKg { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    public ApplicationUser? User { get; set; }
}

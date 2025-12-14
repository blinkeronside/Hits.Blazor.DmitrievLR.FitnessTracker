using Hits.Blazor.DmitrievLR.FitnessTracker.Data;
using Hits.Blazor.DmitrievLR.FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Hits.Blazor.DmitrievLR.FitnessTracker.Services;

public class StatisticsService
{
    private readonly ApplicationDbContext _db;

    public StatisticsService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<List<WorkoutVolumePoint>> GetWorkoutVolumesAsync(string userId)
    {
        return await _db.Workouts
            .Where(w => w.UserId == userId)
            .Select(w => new
            {
                w.Date,
                Volume = w.Entries.Sum(e => e.Sets * e.Reps * e.WeightKg)
            })
            .GroupBy(x => x.Date)
            .Select(g => new WorkoutVolumePoint
            {
                Date = g.Key,
                Volume = g.Sum(x => x.Volume)
            })
            .OrderBy(x => x.Date)
            .ToListAsync();
    }

}

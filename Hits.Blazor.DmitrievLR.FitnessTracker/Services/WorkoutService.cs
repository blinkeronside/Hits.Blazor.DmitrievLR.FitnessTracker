using Hits.Blazor.DmitrievLR.FitnessTracker.Data;
using Hits.Blazor.DmitrievLR.FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Hits.Blazor.DmitrievLR.FitnessTracker.Services;

public class WorkoutService
{
    private readonly ApplicationDbContext _db;

    public WorkoutService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<List<Workout>> GetAllForUserAsync(string userId)
    {
        return await _db.Workouts
            .Where(w => w.UserId == userId)
            .OrderByDescending(w => w.Date)
            .ToListAsync();
    }

    public async Task<Workout?> GetByIdAsync(int id)
    {
        return await _db.Workouts
            .Include(w => w.Entries)
            .ThenInclude(e => e.Exercise)
            .FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<int> CreateAsync(Workout workout)
    {
        _db.Workouts.Add(workout);
        await _db.SaveChangesAsync();
        return workout.Id;
    }

    public async Task DeleteAsync(int id)
    {
        var workout = await _db.Workouts
            .Include(w => w.Entries)
            .FirstOrDefaultAsync(w => w.Id == id);

        if (workout == null)
            return;

        _db.WorkoutEntries.RemoveRange(workout.Entries);
        _db.Workouts.Remove(workout);

        await _db.SaveChangesAsync();
    }

}

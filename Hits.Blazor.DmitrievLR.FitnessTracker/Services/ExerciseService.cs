using Hits.Blazor.DmitrievLR.FitnessTracker.Data;
using Hits.Blazor.DmitrievLR.FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Hits.Blazor.DmitrievLR.FitnessTracker.Services;

public class ExerciseService
{
    private readonly ApplicationDbContext _db;

    public ExerciseService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<List<Exercise>> GetAllAsync()
    {
        return await _db.Exercises
            .OrderBy(e => e.Name)
            .ToListAsync();
    }

    public async Task<Exercise?> GetByIdAsync(int id)
    {
        return await _db.Exercises.FindAsync(id);
    }

    public async Task AddAsync(Exercise exercise)
    {
        _db.Exercises.Add(exercise);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Exercise exercise)
    {
        _db.Exercises.Update(exercise);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var exercise = await _db.Exercises.FindAsync(id);
        if (exercise != null)
        {
            _db.Exercises.Remove(exercise);
            await _db.SaveChangesAsync();
        }
    }
}

using Hits.Blazor.DmitrievLR.FitnessTracker.Data;
using Hits.Blazor.DmitrievLR.FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Hits.Blazor.DmitrievLR.FitnessTracker.Services;

public class WorkoutEntryService
{
    private readonly ApplicationDbContext _db;

    public WorkoutEntryService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task UpdateAsync(WorkoutEntry entry)
    {
        _db.WorkoutEntries.Update(entry);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entry = await _db.WorkoutEntries.FindAsync(id);
        if (entry != null)
        {
            _db.WorkoutEntries.Remove(entry);
            await _db.SaveChangesAsync();
        }
    }
}

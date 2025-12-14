using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hits.Blazor.DmitrievLR.FitnessTracker.Models;

namespace Hits.Blazor.DmitrievLR.FitnessTracker.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Exercise> Exercises => Set<Exercise>();
        public DbSet<Workout> Workouts => Set<Workout>();
        public DbSet<WorkoutEntry> WorkoutEntries => Set<WorkoutEntry>();
        public DbSet<BodyWeightEntry> BodyWeightEntries => Set<BodyWeightEntry>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);

            builder.Entity<Exercise>()
                .HasIndex(x => x.Name)
                .IsUnique();

            builder.Entity<Workout>()
                .HasIndex(x => new { x.UserId, x.Date });

            builder.Entity<Workout>()
                .HasMany(x => x.Entries)
                .WithOne(x => x.Workout)
                .HasForeignKey(x => x.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<WorkoutEntry>()
                .Property(x => x.WeightKg)
                .HasPrecision(6, 2);

            builder.Entity<BodyWeightEntry>()
                .Property(x => x.WeightKg)
                .HasPrecision(6, 2);
        }

    }
}

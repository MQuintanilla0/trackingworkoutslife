
using Microsoft.EntityFrameworkCore;
using TrackingWorkoutsApp.Data;
using TrackingWorkoutsApp.DTO;
using TrackingWorkoutsApp.Models;

namespace TrackingWorkoutsApp.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly AppDbContext _context;

        public WorkoutService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkoutSummaryDto>> GetAllAsync(int userId)
        {
            return await _context.Workouts
                .Where(w => w.UserId == userId)
                .Include(w => w.Exercises)
                    .ThenInclude(e => e.Sets)
                .Select(w => new WorkoutSummaryDto
                {
                    Id = w.Id,
                    TimeOfWorkout = w.TimeofWorkout,
                    Location = w.LocationId,
                    ExerciseCount = w.Exercises.Count,
                    Exercises = w.Exercises.Select(e => new ExerciseSummaryDto
                    {
                        Id = e.Id,
                        Name = e.Name,
                        SetCount = e.Sets.Count
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<WorkoutDetailDto?> GetByIdAsync(int id, int userId)
        {
            return await _context.Workouts
                .Where(w => w.Id == id && w.UserId == userId)
                .Include(w => w.Exercises)
                    .ThenInclude(e => e.Sets)
                .Select(w => new WorkoutDetailDto
                {
                    Id = w.Id,
                    TimeOfWorkout = w.TimeofWorkout,
                    Location = w.LocationId,
                    Exercises = w.Exercises.Select(e => new ExerciseDetailDto
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Sets = e.Sets.Select(s => new SetDto
                        {
                            Id = s.Id,
                            NumberOfReps = s.NumberofReps,
                            Weight = s.Weight
                        }).ToList()
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<WorkoutSummaryDto> CreateAsync(int userId, CreateWorkoutDto dto)
        {
            var workout = new Workout
            {
                UserId = userId,
                TimeofWorkout = dto.TimeOfWorkout,
                LocationId = dto.Location,
                Exercises = new List<Exercise>()
            };

            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            return new WorkoutSummaryDto
            {
                Id = workout.Id,
                TimeOfWorkout = workout.TimeofWorkout,
                Location = workout.LocationId,
                ExerciseCount = 0,
                Exercises = new List<ExerciseSummaryDto>()
            };
        }
    }
}

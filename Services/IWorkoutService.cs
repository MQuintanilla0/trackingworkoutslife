
using TrackingWorkoutsApp.DTO;
namespace TrackingWorkoutsApp.Services
{
    public interface IWorkoutService
    {
        // sumario de workouts
        Task<List<WorkoutSummaryDto>> GetAllAsync(int userId);
   

        // workout specifico
        Task<WorkoutDetailDto?> GetByIdAsync(int id, int userId);
        // crear workout nuevo
        Task<WorkoutSummaryDto> CreateAsync(int userId, CreateWorkoutDto dto);

    }
}

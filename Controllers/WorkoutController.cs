using TrackingWorkoutsApp.DTO;
using Microsoft.AspNetCore.Mvc;
using TrackingWorkoutsApp.Services;
namespace TrackingWorkoutsApp.Controllers

{


    namespace TrackingWorkoutsApp.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class WorkoutsController : ControllerBase
        {
            private readonly IWorkoutService _workoutService;

            public WorkoutsController(IWorkoutService workoutService)
            {
                _workoutService = workoutService;
            }

            // GET /api/workouts
            [HttpGet]
            public async Task<IActionResult> GetWorkouts()
            {
                // userId 1 por ahora
                var workouts = await _workoutService.GetAllAsync(1);
                return Ok(workouts);
            }

            // GET /api/workouts/5
            [HttpGet("{id}")]
            public async Task<IActionResult> GetWorkout(int id)
            {
                var workout = await _workoutService.GetByIdAsync(id, 1);
                if (workout == null) return NotFound();
                return Ok(workout);
            }

            // POST /api/workouts
            [HttpPost]
            public async Task<IActionResult> CreateWorkout([FromBody] CreateWorkoutDto dto)
            {
                var workout = await _workoutService.CreateAsync(1, dto);
                return CreatedAtAction(nameof(GetWorkout), new { id = workout.Id }, workout);
            }
        }
    }
}

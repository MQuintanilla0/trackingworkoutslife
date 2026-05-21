namespace TrackingWorkoutsApp.DTO
{
    // detalles de set dentro de ejercicios
    public class SetDto
    {
        public int Id { get; set; }
        public int NumberOfReps { get; set; }
        public float Weight { get; set; }
    }

    // exercise detalles dentro de workouts
    public class ExerciseDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SetDto> Sets { get; set; }
    }

    // preview de ejercicios dentro de workouts
    public class ExerciseSummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SetCount { get; set; }
    }

    // GET /api/workouts , sumario de ejercicios
    public class WorkoutSummaryDto
    {
        public int Id { get; set; }
        public DateTime TimeOfWorkout { get; set; }
        public string? Location { get; set; }
        public int ExerciseCount { get; set; }
        public List<ExerciseSummaryDto> Exercises { get; set; }
    }

    // GET /api/workouts/{id} , vista detallada de workouts
    public class WorkoutDetailDto
    {
        public int Id { get; set; }
        public DateTime TimeOfWorkout { get; set; }
        public string? Location { get; set; }
        public List<ExerciseDetailDto> Exercises { get; set; }
    }

    // POST /api/workouts - para crear un workout
    public class CreateWorkoutDto
    {
        public DateTime TimeOfWorkout { get; set; }
        public string? Location { get; set; }
    }
}
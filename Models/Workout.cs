namespace TrackingWorkoutsApp.Models
{
    public class Workout
    {
        public int Id { get; set; }

        public DateTime TimeofWorkout { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string? LocationId {get; set; }
            public List<Exercise> Exercises { get; set; }  // one workout has many exercises

    }
}

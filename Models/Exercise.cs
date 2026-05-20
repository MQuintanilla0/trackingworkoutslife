namespace TrackingWorkoutsApp.Models
{
    public class Exercise
    {

        public int Id { get; set; }

        public int WorkoutId { get; set; } // foreign key to workout
        public Workout Workout { get; set; }

        public string Name { get; set; }

        public List<Set> Sets { get; set; }  // one exercise has many sets

    }
}

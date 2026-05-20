namespace TrackingWorkoutsApp.Models
{
    public class Set
    { 
        public int Id { get; set; }

        public int NumberofReps { get; set; }

        public float Weight { get; set; }  // kg or lbs, useful for stats later
        public int ExerciseId { get; set; }  // foreign key to Exercise
        public Exercise Exercise { get; set; }

    }
}

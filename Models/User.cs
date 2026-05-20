namespace TrackingWorkoutsApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public List<Workout> Workouts { get; set; }  // add this
    }
}

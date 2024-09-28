public class Volunteer
{
    public int VolunteerID { get; set; }
    public int UserID { get; set; }
    public int ProjectID { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string AssignedTasks { get; set; }
    
    // Relationships
    public User User { get; set; }
    public ReliefProject Project { get; set; }
}

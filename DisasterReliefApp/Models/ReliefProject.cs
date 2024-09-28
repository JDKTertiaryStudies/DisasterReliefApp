public class ReliefProject
{
    public int ProjectID { get; set; }
    public string ProjectName { get; set; }
    public string Location { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
    
    // Relationships
    public ICollection<Volunteer> Volunteers { get; set; }
    public ICollection<Resource> Resources { get; set; }
}

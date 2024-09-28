public class User
{
    public int UserID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Phone { get; set; }
    public string Role { get; set; }
    public string PasswordHash { get; set; }
    
    // Relationships
    public ICollection<Volunteer> Volunteers { get; set; }
    public ICollection<Donation> Donations { get; set; }
}

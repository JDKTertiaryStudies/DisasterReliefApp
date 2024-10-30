using System;

namespace ReliefManagementApp.Models
{
    public class Volunteer
    {
        public int VolunteerID { get; set; }
        public int UserID { get; set; }
        public string ProjectID { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string AssignedTasks { get; set; }

        public User User { get; set; }
        public ReliefProject Project { get; set; }
    }
}

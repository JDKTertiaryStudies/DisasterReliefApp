using System;

namespace ReliefManagementApp.Models
{
    public class IncidentReport
    {
        public int IncidentReportID { get; set; }
        public int UserID { get; set; }
        public string IncidentDetails { get; set; }
        public DateTime DateReported { get; set; }

        public User User { get; set; }
    }
}

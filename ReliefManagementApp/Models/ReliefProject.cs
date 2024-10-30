using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReliefManagementApp.Models
{
    public class ReliefProject
    {
        [Key]  // This specifies that ProjectID is the primary key
        public string ProjectID { get; set; }  // Assuming ProjectID is used as the unique identifier for each project


        [Required]
        [StringLength(150)]
        public string ProjectName { get; set; }

        [Required]
        [StringLength(200)]
        public string Location { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(30)]
        public string Status { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        // Navigation properties (if applicable)
        public ICollection<Resource> Resources { get; set; }
        public ICollection<Volunteer> Volunteers { get; set; }
    }
}

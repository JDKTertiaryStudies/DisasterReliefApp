using System;
using System.ComponentModel.DataAnnotations;

namespace DisasterReliefApp.Models
{
    public class IncidentReport
    {
        public int Id { get; set; }

        [Required]
        public string DisasterType { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime DateReported { get; set; }

        [Required]
        public string Description { get; set; }
    }
}

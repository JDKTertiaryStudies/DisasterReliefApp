using System.ComponentModel.DataAnnotations;

namespace DisasterReliefApp.Models
{
    public class Donation
    {
        public int Id { get; set; }

        [Required]
        public string ResourceType { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string DonorName { get; set; }

        public string ContactInfo { get; set; }
    }
}

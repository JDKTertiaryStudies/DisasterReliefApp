using System;

namespace ReliefManagementApp.Models
{
    public class Donation
    {
        public int DonationID { get; set; }
        public int UserID { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string PaymentMethod { get; set; }

        public User User { get; set; }
    }
}

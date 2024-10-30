namespace ReliefManagementApp.Models
{
    public class Resource
    {
        public int ResourceID { get; set; }
        public string ProjectID { get; set; }
        public string ResourceName { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }

        public ReliefProject Project { get; set; }
    }
}

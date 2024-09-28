public class Resource
{
    public int ResourceID { get; set; }
    public int ProjectID { get; set; }
    public string ResourceName { get; set; }
    public int Quantity { get; set; }
    public string Status { get; set; }
    
    // Relationships
    public ReliefProject Project { get; set; }
}

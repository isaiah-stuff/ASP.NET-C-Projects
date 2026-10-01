namespace SportsPlay.Models;

public partial class Supplier
{
    public Supplier()
    {
        Product = new HashSet<Product>();
    }

    public int SupplierID { get; set; }
    public string? Supplier1 { get; set; }
    public string? PointOfContact { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Phone { get; set; }
    public string? EmailAddress { get; set; }

    public virtual ICollection<Product> Product { get; set; }
}

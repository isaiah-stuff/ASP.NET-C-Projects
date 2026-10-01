namespace SportsPlay.Models;

public partial class Category
{
    public Category()
    {
        Product = new HashSet<Product>();
    }

    public int CategoryID { get; set; }
    public string? Category1 { get; set; }

    public virtual ICollection<Product> Product { get; set; }
}

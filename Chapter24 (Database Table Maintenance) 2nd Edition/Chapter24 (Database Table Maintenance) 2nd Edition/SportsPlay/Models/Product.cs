using System.ComponentModel.DataAnnotations;

namespace SportsPlay.Models;

public partial class Product
{
    public Product()
    {
        OrderLine = new HashSet<OrderLine>();
    }

    [Display(Name = "Product")]
    public int ProductID { get; set; }

    [Display(Name = "Category")]
    public int? CategoryID { get; set; }

    [Display(Name = "Supplier")]
    public int? SupplierID { get; set; }

    [Display(Name = "Product")]
    public string? Product1 { get; set; }

    [Display(Name = "Description")]
    public string? Description { get; set; }

    [Display(Name = "Image")]
    public string? Image { get; set; }

    [Display(Name = "Price")]
    public decimal? Price { get; set; }

    [Display(Name = "Number in Stock")]
    public byte? NumberInStock { get; set; }

    [Display(Name = "Number on Order")]
    public byte? NumberOnOrder { get; set; }

    [Display(Name = "Reorder Level")]
    public byte? ReorderLevel { get; set; }

    public virtual Category? Category { get; set; }
    public virtual Supplier? Supplier { get; set; }
    public virtual ICollection<OrderLine> OrderLine { get; set; }
}

using System;
using System.Collections.Generic;

namespace Stuffle.Isaiah.Exam3.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderLine = new HashSet<OrderLine>();
        }

        public int ProductID { get; set; }
        public int? CategoryID { get; set; }
        public int? SupplierID { get; set; }
        public string? Product1 { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public decimal? Price { get; set; }
        public byte? NumberInStock { get; set; }
        public byte? NumberOnOrder { get; set; }
        public byte? ReorderLevel { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}

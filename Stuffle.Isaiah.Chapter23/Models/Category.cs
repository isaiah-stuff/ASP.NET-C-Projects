using System;
using System.Collections.Generic;

namespace Stuffle.Isaiah.Chapter23.Models
{
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
}

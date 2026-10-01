using System;
using System.Collections.Generic;

namespace Stuffle.Isaiah.Chapter24.Models
{
    public partial class OrderLine
    {
        public int OrderLineID { get; set; }
        public int? OrderID { get; set; }
        public int? ProductID { get; set; }
        public decimal? Price { get; set; }
        public byte? Quantity { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}

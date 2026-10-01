using System;
using System.Collections.Generic;

namespace Stuffle.Isaiah.Exam3.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderLine = new HashSet<OrderLine>();
        }

        public int OrderID { get; set; }
        public int? CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public int? ShipperID { get; set; }
        public DateTime? Date { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleInitial { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Phone { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Shipper? Shipper { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}

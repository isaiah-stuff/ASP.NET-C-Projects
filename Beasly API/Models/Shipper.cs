using System;
using System.Collections.Generic;

namespace Stuffle.Isaiah.Chapter23.Models
{
    public partial class Shipper
    {
        public Shipper()
        {
            Order = new HashSet<Order>();
        }

        public int ShipperID { get; set; }
        public string? Shipper1 { get; set; }
        public string? PointOfContact { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Phone { get; set; }
        public string? EmailAddress { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}

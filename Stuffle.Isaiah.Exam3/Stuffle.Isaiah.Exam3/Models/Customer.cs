using System;
using System.Collections.Generic;

namespace Stuffle.Isaiah.Exam3.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int CustomerID { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleInitial { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Phone { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public string? Notes { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}

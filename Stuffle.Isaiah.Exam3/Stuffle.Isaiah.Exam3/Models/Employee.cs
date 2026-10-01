using System;
using System.Collections.Generic;

namespace Stuffle.Isaiah.Exam3.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Order = new HashSet<Order>();
        }

        public int EmployeeID { get; set; }
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
        public string? Status { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stuffle.Isaiah.Chapter24.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }


        [Display(Name = "Customer")]

        public int CustomerID { get; set; }


        [Display(Name = "Last Name")]
        public string? LastName { get; set; }


        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Middle Initial")]
        public string? MiddleInitial { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Display(Name = "City")]
        public string? City { get; set; }

        [Display(Name = "State")]
        public string? State { get; set; }

        [Display(Name = "Zip Code")]
        public string? ZipCode { get; set; }

        [Display(Name = "Phone")]
        public string? Phone { get; set; }

        [Display(Name = "Email Address")]
        public string? EmailAddress { get; set; }

        [Display(Name = "Status")]
        public string? Password { get; set; }

        [Display(Name = "Notes")]
        public string? Notes { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}

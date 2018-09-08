using System;
using System.Collections.Generic;

namespace RemoteHotel.DAL.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;

namespace RemoteHotel.DAL.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        public int AccountType { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
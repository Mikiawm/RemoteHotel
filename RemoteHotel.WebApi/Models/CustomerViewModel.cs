using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteHotel.WebApi.Models
{
    public class CustomerViewModel
    {
        public DateTime CreatedDate { get; set; }
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<ReservationViewModel> Reservations { get; set; }
        public string FirstName { get; set; }
        public int AccountType { get; internal set; }
        public bool Authorized { get; internal set; }
    }
}
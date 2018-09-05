using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteHotel.Client.Models
{
    public class AddRentalModel
    {
        public int CustomerId { get; set; }

        public int RoomId { get; set; }

        public string RentalPassword { get; set; }

        public DateTime ExpiredDateTime { get; set; }
    }
}
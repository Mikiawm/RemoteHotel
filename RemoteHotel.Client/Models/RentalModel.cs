using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteHotel.Client.Models
{
    public class RentalModel
    {
        public int RentalId { get; set; }

        public RoomModel Room { get; set; }

        public DateTime ExpiredDate { get; set; }

        public string RentalPassword { get; set; }

        public CustomerModel Customer { get; set; }
    }
}
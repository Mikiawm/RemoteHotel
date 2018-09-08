using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteHotel.Client.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        public IList<RoomModel> Rentals { get; set; }

        public string CustomerName { get; set; }

    }
}
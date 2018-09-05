using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteHotel.Client.Models
{
    public class HotelDashboardModel
    {
        public string HotelName { get; set; }

        public IList<RoomModel> Rooms { get; set; }

        public IList<CustomerModel> Customers { get; set; }

        
    }
}
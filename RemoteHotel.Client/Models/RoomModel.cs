using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteHotel.Client.Models
{
    public class RoomModel
    {
        public int RoomId { get; set; }

        public IList<CustomerModel> RoomCustomers { get; set; }

        public string RoomNumber { get; set; }
    }
}
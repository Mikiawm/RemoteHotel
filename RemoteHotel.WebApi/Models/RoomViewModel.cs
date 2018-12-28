using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteHotel.WebApi.Models
{
    public class RoomViewModel
    {
        public int HotelId { get; set; }
        public string RoomNumber { get; set; }
        public int Beds { get; set; }
        public int Standard { get; set; }
    }
}
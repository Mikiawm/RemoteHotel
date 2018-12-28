using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteHotel.WebApi.Models
{
    public class HotelViewModel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public IEnumerable<RoomViewModel> Rooms { get; set; }
    }
}
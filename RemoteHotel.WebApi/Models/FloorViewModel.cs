using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteHotel.WebApi.Models
{
    public class FloorViewModel
    {
        public int FloorId { get; set; }
        public int HotelId { get; set; }
        public int Level { get; set; }
        public IEnumerable<RoomViewModel> Rooms { get; set; }
    }
}
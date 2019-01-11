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
        public int SingleBeds { get; set; }
        public int DoubleBeds { get; set; }
        public string Description { get; set; }
        public string RoomType { get; set; }
    }
}
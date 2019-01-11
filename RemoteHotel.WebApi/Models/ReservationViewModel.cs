using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteHotel.WebApi.Models
{
    public class ReservationViewModel
    {
        public int CustomerId { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public DateTime CheckOutDateTime { get; set; }
        public int RoomId { get; set; }
        public string ReservationKey { get; set; }
        public int ReservationId { get; set; }
    }
}
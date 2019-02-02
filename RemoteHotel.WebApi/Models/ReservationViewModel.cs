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
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int RoomId { get; set; }
        public string ReservationKey { get; set; }
        public int ReservationId { get; set; }
        public string RoomNumber { get; internal set; }
    }
}
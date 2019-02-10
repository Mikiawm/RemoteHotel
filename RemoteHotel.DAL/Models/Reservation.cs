using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RemoteHotel.DAL.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public virtual ICollection<AccessLog> AccessLogs { get; set; }

        public string ReservationKey { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public Boolean Accepted { get; set; }
    }
}
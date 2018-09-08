using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RemoteHotel.DAL.Models
{
    public class Rental
    {
        public int RentalId { get; set; }

        public int CustomerId { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
        public virtual Customer Customer { get; set; }

        public string RoomKey { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime ExpiredDateTime { get; set; }

    }
}
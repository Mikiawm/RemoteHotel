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
        [Key, Column(Order = 0)]
        public int CustomerId { get; set; }

        [Key, Column(Order = 1)]
        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
        public virtual Customer Customer { get; set; }

        public string RoomKey { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime ExpiredDAteTime { get; set; }

    }
}
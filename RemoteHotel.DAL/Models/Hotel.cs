using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RemoteHotel.DAL.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        public string HotelName { get; set; }

        //public virtual ICollection<Room> Rooms { get; set; }

        public virtual ICollection<Floor> Floors { get; set; }

    }
}
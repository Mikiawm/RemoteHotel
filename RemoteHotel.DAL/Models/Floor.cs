using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteHotel.DAL.Models
{
    public class Floor
    {
        public int Id { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }

        public virtual Hotel Hotel { get; set; }

        public virtual int HotelId { get; set; }

        public int Level { get; set; }
    }
}
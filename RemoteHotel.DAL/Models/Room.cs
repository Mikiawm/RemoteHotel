using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RemoteHotel.DAL.Models
{
    public class Room
    {
        public int Id { get; set; }

        public string RoomNumber { get; set; }

        public int Standard { get; set; }

        public int Beds { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public string Description { get; set; }

        public string RoomType { get; set; }

        public virtual Hotel Hotel{ get; set; }

        public virtual int HotelId { get; set; }

        public int SingleBeds { get; set; }

        public int DoubleBeds { get; set; }
    }
}
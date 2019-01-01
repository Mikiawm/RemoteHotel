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

        public int Status { get; set; }

        public int Standard { get; set; }

        public int Beds { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }

        public virtual Floor Floor { get; set; }

        public virtual int FloorId { get; set; }

    }
}
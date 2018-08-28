using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RemoteHotel.DAL.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        public int Id { get; set; }

        public string HotelName { get; set; }

    }
}
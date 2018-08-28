using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RemoteHotel.DAL.Models
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDateTime { get; set; }

        public int RoomId { get; set; }

        public DateTime OrderDateFrom { get; set; }

        public DateTime OrderDateTo { get; set; }

        public int HotelId { get; set; }

        public double OrderCost { get; set; }

        public int? CustomerId { get; set; }


    }
}
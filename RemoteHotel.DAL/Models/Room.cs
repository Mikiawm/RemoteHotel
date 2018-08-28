using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RemoteHotel.DAL.Models
{
    [Table("Room")]
    public class Room
    {
        public int Id { get; set; }

        [Required]
        public string RoomNumber { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public int Standard { get; set; }

        [Required]
        public int Beds { get; set; }
    }
}
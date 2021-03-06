﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteHotel.DAL.Models
{
    public class AccessLog
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string Info { get; set; }

        public bool Status { get; set; }

        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteHotel.WebApi.Models
{
    public class AccessLogViewModel
    {
        public int LogId { get; set; }
        public string CardId { get; set; }
        public DateTime CreateDate { get; set; }
        public string PasswordHash { get; set; }
        public string Info { get; set; }
        public bool Status { get; set; }
        public int ReservationId { get; internal set; }
    }
}
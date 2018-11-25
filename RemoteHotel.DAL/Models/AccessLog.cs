using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteHotel.DAL.Models
{
    public class AccessLog
    {
        public int LogId { get; set; }

        public DateTime CreateDate { get; set; }

        public string Info { get; set; }

        public bool Status { get; set; }

        public string CardId { get; set; }

        public string PasswordHash { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteHotel.WebApi.Models
{
    public class UserLoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
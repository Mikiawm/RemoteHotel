using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using RemoteHotel.Client.Models;

namespace RemoteHotel.Client.Services
{
    public class LoginService
    {
        readonly string uri = ConfigurationManager.AppSettings["WebApiAdress"];
        private HttpClient client = new HttpClient();

        public LoginService()
        {
            
        }
        public bool LoginToApp(string login, string password)
        {
            return true;
        }

    }
}
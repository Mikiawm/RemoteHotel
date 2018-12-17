using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace RemoteHotel.WebApi.Providers
{
    public class MembershipProvider : IMembershipProvider
    {
        public List<Claim> GetUserClaims(string username)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            claims.Add(new Claim(ClaimTypes.Email, "admin93@gmail.com"));
            return claims;
        }

        public bool VerifyUserPassword(string username, string password)
        {
            if (username == "admin93" && password == "password")
                return true;
            return false;
        }
    }

    public interface IMembershipProvider
    {
        bool VerifyUserPassword(string username, string password);
        List<Claim> GetUserClaims(string username);
    }
}
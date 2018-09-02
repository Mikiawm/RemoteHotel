using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL.Interfaces
{
    public interface IAccountRepository : IRepository<User>
    {
        User GetUserByLoginPassword(string login, string password);
        IEnumerable<User> GetUsersByLogin(string login);

    }
}
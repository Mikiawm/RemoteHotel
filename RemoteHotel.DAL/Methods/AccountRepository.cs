using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using RemoteHotel.DAL.Interfaces;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL.Methods
{
    public class AccountRepository : Repository<User>, IAccountRepository
    {

        public AccountRepository(RemoteHotelContext context)
            : base(context)
        {
        }

        public User GetUserByLoginPassword(string login, string password)
        {
            return RemoteHotelContext.Users.FirstOrDefault(c => c.Login == login && c.Password == password);
        }

        public IEnumerable<User> GetUsersByLogin(string login)
        {
            return RemoteHotelContext.Users.Where(u => u.Login == login);
        }
        public RemoteHotelContext RemoteHotelContext
        {
            get { return Context as RemoteHotelContext; }
        }
    }
}
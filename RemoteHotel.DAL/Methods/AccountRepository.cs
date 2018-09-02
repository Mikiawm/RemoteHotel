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
        private readonly RemoteHotelContext _context;

        public AccountRepository(RemoteHotelContext context)
            : base(context)
        {
        }

        //public RemoteHotelContext RemoteHotelContext
        //{
        //    get { return Context as RemoteHotelContext; }
        //}
    }
}
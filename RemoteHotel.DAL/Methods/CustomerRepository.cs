using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using RemoteHotel.DAL.Interfaces;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL.Methods
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly RemoteHotelContext _context;

        public CustomerRepository(RemoteHotelContext context)
            :base(context)
        {
            this._context = context;
        }


        public IEnumerable<Customer> GetCustomersByHotelId(int hotelId)
        {
            return _context.Customers.Where(x => x.CustomerRooms.Any(z => z.Room.CurrentHotel.Id == hotelId));
        }
    }
}
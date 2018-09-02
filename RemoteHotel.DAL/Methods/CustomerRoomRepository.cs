using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RemoteHotel.DAL.Interfaces;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL.Methods
{
    public class CustomerRoomRepository : Repository<CustomerRoom>, ICustomerRoomRepository
    {
        private readonly RemoteHotelContext _context;

        public CustomerRoomRepository(RemoteHotelContext context)
            : base(context)
        {
            this._context = context;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RemoteHotel.DAL.Interfaces;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL.Methods
{
    public class RoomRepository : Repository<Room>, IRoomRepository 
    {
        private readonly RemoteHotelContext _context;

        public RoomRepository(RemoteHotelContext context)
            : base(context)
        {
            this._context = context;
        }
    }
}
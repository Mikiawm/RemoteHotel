using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RemoteHotel.DAL.Interfaces;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL.Methods
{
    public class FloorRepository : Repository<Floor>, IFloorRepository
    {
        private readonly RemoteHotelContext _context;

        public FloorRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<Floor> GetFloorsByHotel(int hotelId)
        {
            return _context.Floors.Where(x => x.HotelId == hotelId);
        }
    }
}
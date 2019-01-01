using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL.Interfaces
{
    public interface IFloorRepository : IRepository<Floor>
    {
        IEnumerable<Floor> GetFloorsByHotel(int hotelId);
    }
}
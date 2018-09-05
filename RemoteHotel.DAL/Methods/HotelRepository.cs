using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RemoteHotel.DAL.Interfaces;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL.Methods
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        public HotelRepository(DbContext context) : base(context)
        {
        }
    }
}
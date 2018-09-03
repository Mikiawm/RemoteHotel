using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL.Interfaces
{
    public interface IRentalRepository : IRepository<Rental>
    {
        void Add(Customer customer, Room room, string key, DateTime expireDateTime);

    }
}
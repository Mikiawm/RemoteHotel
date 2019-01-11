using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL.Interfaces
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        void Add(Customer customer, Room room, string key, DateTime checkInDateTime, DateTime checkOutDateTime);

    }
}
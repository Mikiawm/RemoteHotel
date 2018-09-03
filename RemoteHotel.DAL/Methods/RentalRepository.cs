using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RemoteHotel.DAL.Interfaces;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL.Methods
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        private readonly RemoteHotelContext _context;

        public RentalRepository(RemoteHotelContext context)
            : base(context)
        {
            this._context = context;
        }

        public void Add(Customer customer, Room room, string key, DateTime expiredDateTime)
        {
            var newRental = new Rental
            {
                CustomerId = customer.Id,
                Customer = customer,
                RoomId = room.Id,
                Room = room,
                RoomKey = key,
                CreateDateTime = DateTime.Now,
                ExpiredDAteTime = expiredDateTime
            };
            Context.Set<Rental>().Add(newRental);
        }
    }
}
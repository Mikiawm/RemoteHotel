using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RemoteHotel.DAL.Interfaces;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL.Methods
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private readonly RemoteHotelContext _context;

        public ReservationRepository(RemoteHotelContext context)
            : base(context)
        {
            this._context = context;
        }

        public void Add(Customer customer, Room room, string key, DateTime checkInDateTime, DateTime checkOutDateTime)
        {
            var newReservation = new Reservation
            {
                CustomerId = customer.Id,
                Customer = customer,
                RoomId = room.Id,
                Room = room,
                ReservationKey = key,
                CreateDateTime = DateTime.Now,
                CheckInDate = checkInDateTime,
                CheckOutDate = checkOutDateTime
            };
            Context.Set<Reservation>().Add(newReservation);
        }
    }
}
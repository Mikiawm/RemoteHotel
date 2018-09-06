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

        public Room Get(string roomNumber)
        {
            return _context.Rooms.FirstOrDefault(x => x.RoomNumber == roomNumber);
        }

        public IEnumerable<Room> GetRoomsByHotelId(int hotelId)
        {
            return _context.Rooms.Where(x => x.CurrentHotelId == hotelId);
        }

        public bool OpenRoom(string rentalCode, string roomNumber)
        {
            return _context.CustomerRooms.Any(x => x.RoomKey == rentalCode && x.Room.RoomNumber == roomNumber);
        }

        public bool CloseRoom(string rentalCode, string roomNumber)
        {
            return _context.CustomerRooms.Any(x => x.RoomKey == rentalCode && x.Room.RoomNumber == roomNumber);
        }
    }
}
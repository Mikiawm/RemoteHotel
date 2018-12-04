using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL.Interfaces
{
    public interface IRoomRepository : IRepository<Room>
    {
        Room Get(string roomNumber);
        IEnumerable<Room> GetRoomsByHotelId(int hotelId);
        IEnumerable<Room> GetAllRooms();
        bool OpenRoom(string rentalCode, string roomNumber);
        bool CloseRoom(string rentalCode, string roomNumber);
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<RemoteHotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RemoteHotelContext context)
        {
            context.Users.AddOrUpdate(x => x.Id, new User()
            {
                Id = 1,
                Login = "login1",
                Password = "test1",
                Status = 1,
                AccountType = 1
            },
            new User()
            {
                Id = 2,
                Login = "login2",
                Password = "test2",
                Status = 1,
                AccountType = 1
            });
            context.Hotels.AddOrUpdate(x => x.Id, new Hotel()
            {
                Id = 1,
                HotelName = "HotelNowoczesny",

            });
            context.Rooms.AddOrUpdate(x => x.Id, new Room()
            {
                Id = 1,
                Status = 1,
                Beds = 2,
                RoomNumber = "123",
                Standard = 1,
                CurrentHotelId = 1
            }, new Room()
            {
                Id = 2,
                Status = 2,
                Beds = 2,
                RoomNumber = "223",
                Standard = 1,
                CurrentHotelId = 1
            });
        }
    }
}
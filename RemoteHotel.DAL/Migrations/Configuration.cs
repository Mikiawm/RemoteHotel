using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
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
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}
            try
            {
                var users = new List<User>
                {
                    new User()
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
                    },
                    new User()
                    {
                        Id = 3,
                        Login = "login3",
                        Password = "test3",
                        Status = 1,
                        AccountType = 1
                    }
                };
                var rooms = new List<Room>{
                    new Room()
                    {
                        Id = 1,
                        Status = 1,
                        Beds = 2,
                        RoomNumber = "123",
                        Standard = 1,
                        FloorId = 1
                    }, new Room()
                    {
                        Id = 2,
                        Status = 2,
                        Beds = 2,
                        RoomNumber = "223",
                        Standard = 1,
                        FloorId = 1
                    }
                };
                var floors = new List<Floor>()
                {
                    new Floor()
                    {
                        Id = 1,
                        Level = 0,
                        Rooms = rooms
                    },
                    new Floor()
                    {
                        Id = 2,
                        Level = 1,
                        Rooms = null
                    },
                    new Floor()
                    {
                        Id = 3,
                        Level = 2,
                        Rooms = null
                    },
                    new Floor()
                    {
                        Id = 4,
                        Level = 4,
                        Rooms = null
                    }
                };
                var hotels = new List<Hotel>()
                {
                    new Hotel()
                    {
                        Id = 1,
                        HotelName = "HotelNowoczesny",
                        Floors = floors
                       
                    },
                    new Hotel()
                    {
                        Id = 2,
                        HotelName = "HotelStary",
                        Floors = null
                       
                    }
                };
                var rentals = new List<Rental>()
                {
                    new Rental()
                    {
                        RentalId = 1,
                        RoomId = 1,
                        CustomerId = 1,
                        RoomKey = "ABCD",
                        CreateDateTime = DateTime.Now,
                        ExpiredDateTime = DateTime.Now
                    },
                    new Rental()
                    {
                        RentalId = 2,
                        RoomId = 2,
                        CustomerId = 1,
                        RoomKey = "QWER",
                        CreateDateTime = DateTime.Now,
                        ExpiredDateTime = DateTime.Now
                    }
                };
                var customers = new List<Customer>()
                {
                    new Customer()
                    {
                        CustomerId = 1,
                        CreatedDate = DateTime.Now,
                        Email = "customer1@gmail.com",
                        FirstName = "Customer",
                        LastName = "Separation",
                        Password = "qwerty1",
                        PhoneNumber = "664342546",
                        Rentals = rentals
                    }
                };
                var accessLogs = new List<AccessLog>()
                {
                    new AccessLog()
                    {
                        LogId = 1,
                        CardId = "1234f5f",
                        CreateDate = DateTime.Now,
                        Info = "",
                        Status = true,
                        PasswordHash = ""
                    }
                };
                context.Floors.AddOrUpdate(x => x.Id, floors[0], floors[1], floors[2], floors[3]);
                context.AccessLogs.AddOrUpdate(x => x.LogId, accessLogs[0]);
                context.Users.AddOrUpdate(x => x.Id, users[0]);
                context.Rooms.AddOrUpdate(x => x.Id, rooms[0], rooms[1]);
                context.Hotels.AddOrUpdate(x => x.Id, hotels[0], hotels[1]);
                context.Rentals.AddOrUpdate(x => x.RentalId, rentals[0], rentals[1]);
                context.Customers.AddOrUpdate(x => x.CustomerId, customers[0]);

                context.SaveChanges();
            }

            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
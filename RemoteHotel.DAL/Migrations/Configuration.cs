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

        enum RoomType
        {
            None,         // integer value = 0
            Jednoosobowy,      // 1
            Dwuosobowy,
            Trzyosobowy,
            Czteroosobowy,
            Piecioosobowy 
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
                        SingleBeds = 2,
                        DoubleBeds = 1,
                        RoomType = Enum.GetName(typeof(RoomType), 4),
                        RoomNumber = "123",
                        Standard = 1,
                        HotelId = 1
                    }, new Room()
                    {
                        Id = 2,
                        Beds = 2,
                        SingleBeds = 2,
                        DoubleBeds = 1,
                        RoomType = Enum.GetName(typeof(RoomType), 4),
                        RoomNumber = "223",
                        Standard = 1,
                        HotelId = 1
                    }
                };
                var hotels = new List<Hotel>()
                {
                    new Hotel()
                    {
                        Id = 1,
                        HotelName = "HotelNowoczesny",
                        Rooms = rooms
                       
                    },
                    new Hotel()
                    {
                        Id = 2,
                        HotelName = "HotelStary",
                        Rooms = null
                       
                    }
                };
                var reservations = new List<Reservation>()
                {
                    new Reservation()
                    {
                        Id = 1,
                        RoomId = 1,
                        CustomerId = 1,
                        ReservationKey = "ABCD",
                        CreateDateTime = DateTime.Now,
                        CheckInDate = DateTime.Now,
                        CheckOutDate = DateTime.Now.AddDays(5)
                        
                    },
                    new Reservation()
                    {
                        Id = 2,
                        RoomId = 2,
                        CustomerId = 1,
                        ReservationKey = "QWER",
                        CreateDateTime = DateTime.Now,
                        CheckInDate = DateTime.Now,
                        CheckOutDate = DateTime.Now.AddDays(3)
                    }
                };
                var customers = new List<Customer>()
                {
                    new Customer()
                    {
                        Id = 1,
                        CreatedDate = DateTime.Now,
                        Email = "customer1@gmail.com",
                        FirstName = "Customer",
                        LastName = "Separation",
                        Password = "qwerty1",
                        PhoneNumber = "664342546",
                        Reservations = reservations
                    }
                };
                var accessLogs = new List<AccessLog>()
                {
                    new AccessLog()
                    {
                        Id = 1,
                        CardId = "1234f5f",
                        CreateDate = DateTime.Now,
                        Info = "",
                        Status = true,
                        PasswordHash = ""
                    }
                };
                context.AccessLogs.AddOrUpdate(x => x.Id, accessLogs[0]);
                context.Users.AddOrUpdate(x => x.Id, users[0]);
                context.Rooms.AddOrUpdate(x => x.Id, rooms[0], rooms[1]);
                context.Hotels.AddOrUpdate(x => x.Id, hotels[0], hotels[1]);
                context.Rentals.AddOrUpdate(x => x.Id, reservations[0], reservations[1]);
                context.Customers.AddOrUpdate(x => x.Id, customers[0]);

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
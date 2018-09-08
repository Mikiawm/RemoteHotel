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
            try
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
                context.Rentals.AddOrUpdate(x => x.RentalId, rentals[0], rentals[1]);
                context.Customers.AddOrUpdate(x => x.CustomerId, new Customer()
                {
                    CustomerId = 1,
                    CreatedDate = DateTime.Now,
                    Email = "customer1@gmail.com",
                    FirstName = "Customer",
                    LastName = "Separation",
                    Password = "qwerty1",
                    PhoneNumber = "664342546",
                    Rentals = rentals
                });
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
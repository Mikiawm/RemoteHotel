using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL
{
    public class RemoteHotelContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Reservation> Rentals { get; set; }

        public DbSet<AccessLog> AccessLogs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            BuildRental(modelBuilder);
            BuildRoom(modelBuilder);
            BuildHotel(modelBuilder);
            BuildUser(modelBuilder);
            BuildAccessLog(modelBuilder);
            BuildCustomer(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void BuildCustomer(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(t => t.Id);
        }

        private static void BuildAccessLog(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessLog>()
                .HasKey(t => t.Id);
        }

        private static void BuildUser(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<User>()
                .Property(t => t.AccountType)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(t => t.Login)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(t => t.Password)
                .IsRequired();
        }

        private static void BuildHotel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasMany<Room>(t => t.Rooms)
                .WithRequired(t => t.Hotel)
                .HasForeignKey<int>(t => t.HotelId);

            modelBuilder.Entity<Hotel>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Hotel>()
                .Property(t => t.HotelName)
                .IsRequired();
        }

        private static void BuildRoom(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .Property(t => t.RoomNumber)
                .IsRequired();

            modelBuilder.Entity<Room>()
                .Property(t => t.Beds)
                .IsRequired(); 

            modelBuilder.Entity<Room>()
                .HasKey(x => x.Id);
        }

        private static void BuildRental(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Reservation>()
                .HasRequired(t => t.Customer)
                .WithMany(t => t.Reservations)
                .HasForeignKey(t => t.CustomerId);

            modelBuilder.Entity<Reservation>()
                .HasRequired(t => t.Room)
                .WithMany(t => t.Reservations)
                .HasForeignKey(t => t.RoomId);

            modelBuilder.Entity<Reservation>()
                .Property(t => t.ReservationKey)
                .IsRequired();
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}
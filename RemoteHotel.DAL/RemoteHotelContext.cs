using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL
{
    public class RemoteHotelContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Rental> CustomerRooms { get; set; }          

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Rental>()
                .HasRequired(t => t.Customer)
                .WithMany(t => t.CustomerRooms)
                .HasForeignKey(t => t.CustomerId);

            modelBuilder.Entity<Rental>()
                .HasRequired(t => t.Room)
                .WithMany(t => t.CustomerRooms)
                .HasForeignKey(t => t.RoomId);

            modelBuilder.Entity<Rental>()
                .Property(t => t.RoomKey)
                .IsRequired();

            modelBuilder.Entity<Room>()
                .Property(t => t.RoomNumber)
                .IsRequired();

            modelBuilder.Entity<Room>()
                .Property(t => t.Status)
                .IsRequired();

            modelBuilder.Entity<Room>()
                .Property(t => t.Beds)
                .IsRequired();

            modelBuilder.Entity<Room>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Hotel>()
                .HasMany<Room>(t => t.Rooms)
                .WithRequired(t => t.CurrentHotel)
                .HasForeignKey<int>(t => t.CurrentHotelId);

            modelBuilder.Entity<Hotel>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Hotel>()
                .Property(t => t.HotelName)
                .IsRequired();

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

            base.OnModelCreating(modelBuilder);
        }
    }
}
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

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        public DbSet<AccessLog> AccessLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Rental>()
                .HasRequired(t => t.Customer)
                .WithMany(t => t.Rentals)
                .HasForeignKey(t => t.CustomerId);

            modelBuilder.Entity<Rental>()
                .HasRequired(t => t.Room)
                .WithMany(t => t.Rentals)
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

            //ToDo add Forgiven key to status 
            //modelBuilder.Entity<Room>()
            //    .Property(t => t.Status)
            //    

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


            modelBuilder.Entity<AccessLog>()
                .HasKey(t => t.LogId);

            base.OnModelCreating(modelBuilder);
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
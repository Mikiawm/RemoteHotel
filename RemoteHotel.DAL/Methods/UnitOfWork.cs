using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RemoteHotel.DAL.Interfaces;

namespace RemoteHotel.DAL.Methods
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly RemoteHotelContext _context;
        public UnitOfWork(RemoteHotelContext context)
        {
            _context = context;
            Accounts = new AccountRepository(_context);
            Customers = new CustomerRepository(_context);
            Rooms = new RoomRepository(_context);
            Rentals = new RentalRepository(_context);
        }
        public IRoomRepository Rooms { get; private set; }
        public IAccountRepository Accounts { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IRentalRepository Rentals { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
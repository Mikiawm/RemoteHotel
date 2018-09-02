using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL.Methods
{
    public class CustomerRepository
    {
        private readonly RemoteHotelContext _context;

        public CustomerRepository(RemoteHotelContext context)
        {
            this._context = context;
        }

        public async Task<Customer> CreatCustomerAsync(Customer customer)
        {
            try
            {
                customer.CreatedDate = DateTime.Now;
                var result = _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Customer>> GetAllCustomerAsync()
        {
            try
            {
                return await _context.Customers.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
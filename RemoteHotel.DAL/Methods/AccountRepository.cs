using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL.Methods
{
    public class AccountRepository
    {
        private readonly RemoteHotelContext _context;

        public AccountRepository(RemoteHotelContext context)
        {
            this._context = context;
        }

        public async Task<List<User>> GetUsersAsync(bool active = true)
        {
            try
            {
                var result = new List<User>();

                result = await _context.Users.ToListAsync<User>();

                return result;

            }
            catch (Exception ex)
            {
                throw new System.Exception("Database lockout", ex);
            }
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                var result = _context.Users.FirstOrDefault(x => x.Id == id);

                return result;
            }
            catch (Exception ex)
            {
                throw new System.Exception("Database lockout", ex);
            }
        }

        public async Task<User> GetUserByLogin(string login, string password)
        {
            try
            {
                var result = await _context.Users.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<User>> GetUsersByLogin(string login)
        {
            try
            {
                var result = await _context.Users.Where(x => x.Login == login).ToListAsync();

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
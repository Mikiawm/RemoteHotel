using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.DAL.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer AddAuthorization(int customerId, string password);
    }
}
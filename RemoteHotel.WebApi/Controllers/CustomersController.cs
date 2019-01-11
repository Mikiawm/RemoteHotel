using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using RemoteHotel.DAL;
using RemoteHotel.DAL.Methods;
using RemoteHotel.DAL.Models;
using RemoteHotel.WebApi.Attributes;
using RemoteHotel.WebApi.Models;

namespace RemoteHotel.WebApi.Controllers
{
    [RoutePrefix("api/hotels")]
    [TokenAuthenticate]
    public class CustomersController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public CustomersController()
        {
            this._unitOfWork = new UnitOfWork(new RemoteHotelContext());
        }



        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            var customers = this._unitOfWork.Customers.GetAll()
                .Select(x => new CustomerViewModel
                {
                    CreatedDate = x.CreatedDate,
                    CustomerId = x.Id,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Password = x.Password,
                    PhoneNumber = x.PhoneNumber,
                    Reservations = x.Reservations.Select(z => new ReservationViewModel()
                    {
                        CheckInDateTime = z.CheckInDate,
                        CheckOutDateTime = z.CheckOutDate,
                        ReservationKey = z.ReservationKey
                    })
                });
            return Ok(customers);
        }

        [HttpPost]
        public IHttpActionResult AddCustomer([FromBody] CustomerViewModel customer)
        {
            Customer newCustomer = new Customer();
            newCustomer.PhoneNumber = customer.PhoneNumber;
            newCustomer.CreatedDate = customer.CreatedDate;
            newCustomer.Email = customer.Email;
            newCustomer.LastName = customer.LastName;
            newCustomer.Password = "";
            newCustomer.FirstName = customer.FirstName;

            this._unitOfWork.Customers.Add(newCustomer);

            return Ok(this._unitOfWork.Complete() > 0);
        }

    }
}
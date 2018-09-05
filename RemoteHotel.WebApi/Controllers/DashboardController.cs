using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using RemoteHotel.DAL;
using RemoteHotel.DAL.Methods;
using RemoteHotel.DAL.Models;

namespace RemoteHotel.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class DashboardController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public DashboardController()
        {
            this._unitOfWork = new UnitOfWork(new RemoteHotelContext());
        }

        [HttpGet]
        [Route("hotel/{hotelId}")]
        public IHttpActionResult GetHotelData(int hotelId)
        {

            var dashboardData = new
            {
                Rooms = this._unitOfWork.Customers.GetCustomersByHotelId(hotelId),
                Customers = this._unitOfWork.Rooms.GetRoomsByHotelId(hotelId)
            };
            return Ok(dashboardData);
        }

        [HttpGet]
        [Route("hotel/getAll")]
        public IHttpActionResult GetAllHotels()
        {
            var hotels = this._unitOfWork.Hotels.GetAll();
            return Ok(hotels);
        }

    }
}

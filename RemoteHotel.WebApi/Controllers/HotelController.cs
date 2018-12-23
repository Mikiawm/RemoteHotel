using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RemoteHotel.DAL;
using RemoteHotel.DAL.Methods;
using RemoteHotel.DAL.Models;
using RemoteHotel.WebApi.Attributes;

namespace RemoteHotel.WebApi.Controllers
{
    [RoutePrefix("api")]
    [TokenAuthenticate]
    public class HotelController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public HotelController()
        {
            this._unitOfWork = new UnitOfWork(new RemoteHotelContext());
        }

        [HttpGet]
        [Route("hotels")]
        public IHttpActionResult GetAllHotels()
        {
            return Ok(this._unitOfWork.Hotels.GetAll().Select(x => new
            {
                HotelId = x.Id,
                HotelName = x.HotelName
            }));
        }

        [HttpPost]
        [Route("Hotel")]
        public IHttpActionResult AddHotel(string hotelName)
        {
            Hotel hotel = new Hotel();
            hotel.HotelName = hotelName;
            this._unitOfWork.Hotels.Add(hotel);

            this._unitOfWork.Complete();

            return Ok(hotel.Id);

        }
    }
}

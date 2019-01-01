﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RemoteHotel.DAL;
using RemoteHotel.DAL.Methods;
using RemoteHotel.DAL.Models;
using RemoteHotel.WebApi.Attributes;
using RemoteHotel.WebApi.Models;

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

            //var hotels = this._unitOfWork.Hotels.GetAll().Select(x => new HotelViewModel { HotelId = x.Id, HotelName = x.HotelName, Rooms = x.Rooms.Select(y => new RoomViewModel { RoomNumber = y.RoomNumber, Beds = y.Beds, Standard = y.Standard }) });
            //return Ok(hotels);
            return Ok(true);
        }

        [HttpPost]
        [Route("hotels")]
        public IHttpActionResult AddHotel([FromBody]HotelViewModel hotel)
        {
            Hotel newHotel = new Hotel();
            newHotel.HotelName = hotel.HotelName;
            this._unitOfWork.Hotels.Add(newHotel);

            this._unitOfWork.Complete();

            return Ok(newHotel.Id);

        }
    }
}

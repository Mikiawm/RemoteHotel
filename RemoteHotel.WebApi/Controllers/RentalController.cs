using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RemoteHotel.DAL;
using RemoteHotel.DAL.Methods;
using RemoteHotel.DAL.Models;
using RemoteHotel.WebApi.Services;

namespace RemoteHotel.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class RentalController : ApiController
    {
        [HttpPost]
        [Route("rental/{customerId}/{roomId}/{expiredDateTime}")]
        public IHttpActionResult CreateNewRental(int customerId, int roomId, DateTime expiredDateTime)
        {
            using (var unitOfWork = new UnitOfWork(new RemoteHotelContext()))
            {
                var customer = unitOfWork.Customers.Get(customerId);
                var room = unitOfWork.Rooms.Get(roomId);

                string roomCode = RoomCodeService.GenerateRoomCode();

                unitOfWork.Rentals.Add(customer, room, roomCode, expiredDateTime);
                unitOfWork.Complete();
            }
            return Ok();
        }

        [HttpGet]
        [Route("rental/getAll")]
        public IHttpActionResult GetAllRental()
        {
            Object Rentals;
            using (var unitOfWork = new UnitOfWork(new RemoteHotelContext()))
            {
                Rentals = unitOfWork.Rentals.GetAll();
            }
            return Ok(Rentals);
        }
    }
}

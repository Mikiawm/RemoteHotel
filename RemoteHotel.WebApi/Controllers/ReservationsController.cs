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
using RemoteHotel.WebApi.Attributes;
using RemoteHotel.WebApi.Models;
using RemoteHotel.WebApi.Services;

namespace RemoteHotel.WebApi.Controllers
{
    [RoutePrefix("api")]
    [TokenAuthenticate]
    public class ReservationsConrtoller : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public ReservationsConrtoller()
        {
            this._unitOfWork = new UnitOfWork(new RemoteHotelContext());
        }
        [HttpPost]
        [Route("reservations")]
        public IHttpActionResult CreateNewReservation([FromBody] ReservationViewModel reservation)
        {
            try
            {
                var customer = this._unitOfWork.Customers.Get(reservation.CustomerId);
                var room = this._unitOfWork.Rooms.Get(reservation.RoomId);
                string roomCode = RoomCodeService.GenerateRoomCode();

                int returnInt = this._unitOfWork.Reservations.Add(customer, room, roomCode, reservation.DateFrom, reservation.DateTo);
                this._unitOfWork.Complete();
                return Ok(returnInt);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        [HttpGet]
        [Route("reservations")]
        public IHttpActionResult GetAllReservation()
        {
            try
            {
                var reservations = this._unitOfWork.Reservations.GetAll().Select(x => new ReservationViewModel()
                {
                    CreateDateTime = x.CreateDateTime,
                    DateFrom = x.CheckInDate,
                    DateTo = x.CheckOutDate,
                    RoomId = x.RoomId,
                    ReservationKey = x.ReservationKey,
                    ReservationId = x.Id
                });
                return Ok(reservations);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut]
        [Route("reservations")]
        public IHttpActionResult EditReservation([FromBody]ReservationViewModel reservation)
        {
            return BadRequest();
        }
    }
}

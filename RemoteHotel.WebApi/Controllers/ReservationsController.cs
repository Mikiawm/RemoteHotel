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
using RemoteHotel.WebApi.Models;
using RemoteHotel.WebApi.Services;

namespace RemoteHotel.WebApi.Controllers
{
    [RoutePrefix("api/reservations")]
    public class ReservationsConrtoller : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public ReservationsConrtoller()
        {
            this._unitOfWork = new UnitOfWork(new RemoteHotelContext());
        }
        [HttpPost]
        public IHttpActionResult CreateNewReservation([FromBody] ReservationViewModel reservation)
        {
            try
            {
                var customer = this._unitOfWork.Customers.Get(reservation.CustomerId);
                var room = this._unitOfWork.Rooms.Get(reservation.RoomId);
                string roomCode = RoomCodeService.GenerateRoomCode();

                this._unitOfWork.Reservations.Add(customer, room, roomCode, reservation.CheckInDateTime, reservation.CheckOutDateTime);
                this._unitOfWork.Complete();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            using (var unitOfWork = new UnitOfWork(new RemoteHotelContext()))
            {

            }
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAllReservation()
        {
            try
            {
               var reservations =  this._unitOfWork.Reservations.GetAll().Select(x => new ReservationViewModel()
                {
                    CreateDateTime = x.CreateDateTime,
                    CheckInDateTime = x.CheckInDate,
                    CheckOutDateTime = x.CheckOutDate,
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
        public IHttpActionResult EditReservation([FromBody]ReservationViewModel reservation )
        {
            return BadRequest();
        }
    }
}

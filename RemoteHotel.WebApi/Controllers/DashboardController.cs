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
using RemoteHotel.WebApi.Models;

namespace RemoteHotel.WebApi.Controllers
{
    [RoutePrefix("api/dashboard")]
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
        [Route("freeRooms")]
        public IHttpActionResult GetFreeRooms(DateTime checkInDateTime, DateTime checkOutDateTime)
        {
            try
            {
                var rooms = this._unitOfWork.Rooms.GetAll()
                    .Where(x => x.Reservations.Any(z =>
                        z.CheckInDate >= checkInDateTime && z.CheckOutDate <= checkOutDateTime))
                    .Select(x => new RoomViewModel
                    {
                        RoomNumber = x.RoomNumber,
                        Beds = x.Beds,
                        SingleBeds = x.SingleBeds,
                        DoubleBeds = x.DoubleBeds,
                        Description = x.Description
                    });
                return Ok(rooms);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public class AccessLogViewModel
        {
            public int LogId { get; set; }
            public DateTime CreateDate { get; set; }
            public string PasswordHash { get; set; }
            public string Info { get; set; }
            public bool Status { get; set; }
        }

        [HttpGet]
        [Route("accessLogs")]
        public IHttpActionResult GetAllAccessLogs()
        {
            try
            {
                var accessLogs = this._unitOfWork.AccessLogs.GetAll().Select(x =>
                {
                    var accessLog = new AccessLogViewModel
                    {
                        LogId = x.Id,
                        CreateDate = x.CreateDate,
                        PasswordHash = x.PasswordHash,
                        Info = x.Info,
                        Status = x.Status
                    };
                    return accessLog;
                });
                return Ok(accessLogs);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        public class ReservationListItemViewModel
        {
            public string FirstName { get; set; }
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
            public string RoomNumber { get; set; }
        }

        [HttpGet]
        [Route("reservations")]
        public IHttpActionResult GetAllReservations()
        {
            try
            {
                var reservations = this._unitOfWork.Reservations.GetAll().Select(
                    x => new ReservationListItemViewModel
                    {
                        FirstName = x.Customer.FirstName,
                        CheckInDate = x.CheckInDate,
                        CheckOutDate = x.CheckOutDate,
                        RoomNumber = x.Room.RoomNumber
                    });
                return Ok(reservations);
            }
            catch (Exception e)
            {
                Console.WriteLine();
                throw;
            }
        }

    }
}

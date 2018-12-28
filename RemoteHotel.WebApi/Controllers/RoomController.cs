using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;
using RemoteHotel.DAL;
using RemoteHotel.DAL.Methods;
using RemoteHotel.DAL.Models;
using RemoteHotel.WebApi.Models;

namespace RemoteHotel.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class RoomController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public RoomController()
        {
            this._unitOfWork = new UnitOfWork(new RemoteHotelContext());
        }
        [HttpGet]
        [Route("rooms/{roomNumber}")]
        public Room Get(string roomNumber)
        {
            try
            {
                Room room = this._unitOfWork.Rooms.Get(roomNumber);
                return room;
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(string.Format(ex.Message)),
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(resp);
            }
        }

        [HttpGet]
        [Route("rooms")]
        public Object GetAll()
        {
            try
            {
                var rooms = this._unitOfWork.Rooms.GetAllRooms();
                return rooms;
            }
            catch(Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("rooms/openRoom/{rentalCode}")]
        public bool OpenRoom(string rentalCode, string cardId, string roomNumber)
        {
            try
            {
                var roomStatus = this._unitOfWork.Rooms.OpenRoom(rentalCode, roomNumber);

                AccessLog accessLog = new AccessLog()
                {
                    CreateDate = DateTime.Now,
                    CardId = cardId,
                    Info = "",
                    Status = roomStatus,
                    PasswordHash = rentalCode
                };
                this._unitOfWork.AccessLogs.Add(accessLog);
                

                return roomStatus;
            }
            catch(Exception ex)
            {
                AccessLog accessLog = new AccessLog()
                {
                    CreateDate = DateTime.Now,
                    CardId = cardId,
                    Info = ex.Message,
                    Status = false,
                    PasswordHash = rentalCode
                };
                this._unitOfWork.AccessLogs.Add(accessLog);

                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(string.Format(ex.Message)),
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(resp);
            }
            finally
            {
                this._unitOfWork.Complete();
            }

        }
        [HttpPost]
        [Route("rooms")]
        public IHttpActionResult AddHotel([FromBody]RoomViewModel room)
        {
            Room newRoom = new Room();

            newRoom.CurrentHotelId = room.HotelId;
            newRoom.Beds = room.Beds;
            newRoom.Standard = room.Standard;
            this._unitOfWork.Rooms.Add(newRoom);

            this._unitOfWork.Complete();

            return Ok(newRoom.Id);

        }
    }
}
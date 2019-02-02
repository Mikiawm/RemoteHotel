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
    public class RoomsController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public RoomsController()
        {
            this._unitOfWork = new UnitOfWork(new RemoteHotelContext());
        }
        [HttpGet]
        [Route("rooms/{roomId}")]
        public IHttpActionResult Get(int roomId)
        {
            try
            {
                Room room = this._unitOfWork.Rooms.Get(roomId);

                var roomViewModel = new RoomViewModel()
                {
                    RoomNumber = room.RoomNumber,
                    SingleBeds = room.SingleBeds,
                    DoubleBeds = room.DoubleBeds,
                    Beds = room.Beds,
                    RoomType = room.RoomType
                };
                return Ok(roomViewModel);
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
        public IHttpActionResult GetAll()
        {
            try
            {
                var rooms = this._unitOfWork.Rooms.GetAllRooms().Select(x => new RoomViewModel()
                {
                    RoomNumber = x.RoomNumber,
                    SingleBeds = x.SingleBeds,
                    DoubleBeds = x.DoubleBeds,
                    Beds = x.Beds,
                    Description = x.Description
                });
                return Ok(rooms);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("rooms/openRoom/{rentalCode}")]
        public IHttpActionResult OpenRoom(string rentalCode, string cardId, string roomNumber)
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

                return Ok(roomStatus);
            }
            catch (Exception ex)
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
        public IHttpActionResult AddRoom([FromBody]RoomViewModel room)
        {
            Room newRoom = new Room();

            newRoom.HotelId = room.HotelId;
            newRoom.RoomNumber = room.RoomNumber;
            newRoom.Beds = room.Beds;
            newRoom.Standard = room.Standard;
            this._unitOfWork.Rooms.Add(newRoom);

            this._unitOfWork.Complete();

            return Ok(newRoom.Id);

        }
        [HttpGet]
        [Route("rooms")]
        public IHttpActionResult GetFreeRooms(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                var rooms = this._unitOfWork.Rooms.GetAll()
                    .Where(x => !x.Reservations.Any(z =>
                        (z.CheckInDate >= dateFrom && z.CheckInDate <= dateTo) 
                        || (z.CheckOutDate >= dateFrom && z.CheckOutDate <= dateTo)))
                    .Select(x => new RoomViewModel
                    {
                        RoomId = x.Id,
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
    }

}
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
                    DoubleBeds = room.DoubleBeds,
                    Beds = room.Beds
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
                    RoomId = x.Id,
                    HotelId = x.HotelId,
                    RoomNumber = x.RoomNumber,
                    DoubleBeds = x.DoubleBeds,
                    Beds = x.Beds
                });
                return Ok(rooms);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("rooms/openRoom")]
        public IHttpActionResult OpenRoom(string codePassword, string roomNumber)
        {
            try
            {
                var roomStatus = this._unitOfWork.Rooms.OpenRoom(codePassword, roomNumber);

                AccessLog accessLog = new AccessLog()
                {
                    CreateDate = DateTime.Now,
                    Info = "",
                    Status = roomStatus
                };
                this._unitOfWork.AccessLogs.Add(accessLog);

                return Ok(roomStatus);
            }
            catch (Exception ex)
            {
                AccessLog accessLog = new AccessLog()
                {
                    CreateDate = DateTime.Now,
                    Info = ex.Message,
                    Status = false
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

        [HttpDelete]
        [Route("rooms")]
        public IHttpActionResult DeleteRoom(int roomId)
        {
            this._unitOfWork.Rooms.Remove(roomId);
            this._unitOfWork.Complete();

            return Ok(this._unitOfWork.Complete() > 0);
        }

        [HttpPut]
        [Route("rooms")]
        public IHttpActionResult EditRoom([FromBody]RoomViewModel room)
        {
            Room roomToUpdate = new Room();
            roomToUpdate.Id = room.RoomId;
            roomToUpdate.HotelId = room.HotelId;
            roomToUpdate.RoomNumber = room.RoomNumber;
            roomToUpdate.Beds = room.Beds;
            roomToUpdate.Standard = room.Standard;
            roomToUpdate.DoubleBeds = room.DoubleBeds;

            this._unitOfWork.Rooms.Update(roomToUpdate);
            this._unitOfWork.Complete();

            return Ok(roomToUpdate.Id);

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
                        DoubleBeds = x.DoubleBeds
                    });
                return Ok(rooms);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpGet]
        [Route("rooms")]
        public IHttpActionResult GetFreeRoomsGroupedBy(DateTime dateFrom, DateTime dateTo, string groupedBy)
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
                        DoubleBeds = x.DoubleBeds
                    });

                if (groupedBy == "standard")
                {
                    return Ok(rooms.GroupBy(x => x.Standard));
                }
                else if(groupedBy == "doubleBeds")
                {
                    return Ok(rooms.GroupBy(x => x.DoubleBeds));
                }
                else
                {
                    return Ok(rooms.GroupBy(x => x.Beds));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

}
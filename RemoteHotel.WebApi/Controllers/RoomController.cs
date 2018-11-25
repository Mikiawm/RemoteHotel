using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using RemoteHotel.DAL;
using RemoteHotel.DAL.Methods;
using RemoteHotel.DAL.Models;

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
        [Route("room/{roomNumber}")]
        public Room GetRoom(string roomNumber)
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
        [Route("room/openRoom/{rentalCode}")]
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
    }
}
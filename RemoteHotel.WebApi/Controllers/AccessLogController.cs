using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
    public class AccessLogController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public AccessLogController()
        {
            this._unitOfWork = new UnitOfWork(new RemoteHotelContext());
        }

        [HttpGet]
        [Route("accessLogs")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var accessLogs = this._unitOfWork.AccessLogs.GetAll().Select(x =>
                {
                    var accessLog = new AccessLogViewModel
                    {
                        LogId = x.Id,
                        CreateDate = x.CreateDate,
                        Info = x.Info,
                        Status = x.Status,
                        ReservationId = x.ReservationId
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

        [HttpPost]
        [Route("accessLogs")]
        public HttpResponseMessage CreateAccess([FromBody] AccessLogViewModel item)
        {
            this._unitOfWork.AccessLogs.Add(new AccessLog()
            {
                CreateDate = DateTime.Now,
                Info = item.Info,
                Status = item.Status,
                ReservationId = item.ReservationId
            });
            this._unitOfWork.Complete();
            var response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent("Your Result")
            };

            return response;
        }
    }
}
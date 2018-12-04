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

namespace RemoteHotel.WebApi.Controllers
{
    [RoutePrefix("api")]
    public class AccessLogController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public AccessLogController()
        {
            this._unitOfWork = new UnitOfWork(new RemoteHotelContext());
        }

        public class AccessLogViewModel
        {
            public int LogId { get; set; }
            public string CardId { get; set; }
            public DateTime CreateDate { get; set; }
            public string PasswordHash { get; set; }
            public string Info { get; set; }
            public bool Status { get; set; }
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
                        LogId = x.LogId,
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

        [HttpPost]
        [Route("accessLogs")]
        public HttpResponseMessage CreateAccess([FromBody] AccessLogViewModel item)
        {
            this._unitOfWork.AccessLogs.Add(new AccessLog()
            {
                CardId = item.CardId,
                CreateDate = DateTime.Now,
                Info = item.Info,
                PasswordHash = item.PasswordHash,
                Status = item.Status
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
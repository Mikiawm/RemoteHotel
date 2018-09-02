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
    public class AccountController : ApiController
    {
        private readonly AccountRepository _repository;

        public AccountController()
        {
            this._repository = new AccountRepository(new RemoteHotelContext());
        }

        [HttpGet]
        [Route("login/{login}/{password}")]
        public User Login(string login, string password)
        {
            try
            {
                var user = this._repository.GetUserByLoginPassword(login, password);
                return user;
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
        [Route("user/{login}")]
        public IEnumerable<User> GetUsers(string login)
        {
            try
            {
                var users = this._repository.GetUsersByLogin(login);
                return users;
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
    }
}

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
        public async Task<User> Login(string login, string password)
        {
            try
            {
                var user = await this._repository.(login, password);
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
        public async Task<List<User>> GetUsers(string login)
        {
            try
            {
                var users = await this._repository.GetUsersByLogin(login);
                var users2 = await this._repository.GetUsersAsync();
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

        [HttpGet]
        [Route("user/{id:int}")]
        public async Task<User> GetUsers(int id)
        {
            try
            {
                var user = await this._repository.GetUserById(id);
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
    }
}

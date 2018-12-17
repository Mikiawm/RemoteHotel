using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using RemoteHotel.DAL;
using RemoteHotel.DAL.Methods;
using RemoteHotel.DAL.Models;
using RemoteHotel.WebApi.Models;
using RemoteHotel.WebApi.Services;
using Swagger.Net;

namespace RemoteHotel.WebApi.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            this._unitOfWork = new UnitOfWork(new RemoteHotelContext());
            this._authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IHttpActionResult> Login([FromBody]UserLoginModel user)
        {
            try
            {
                string Token = await _authService.GenerateJwtTokenAsync(user.Login, user.Password);
                return Ok(Token);

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
                var users = this._unitOfWork.Accounts.GetUsersByLogin(login);
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

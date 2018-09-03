using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RemoteHotel.Client.Models;
using RemoteHotel.Client.Services;

namespace RemoteHotel.Client.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            LoginService loginService = new LoginService();
            
            if (ModelState.IsValid)
            {
                var isExist = loginService.LoginToApp(loginModel.Login, loginModel.Password); 
                if (isExist)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginModel);
        }


    }
}
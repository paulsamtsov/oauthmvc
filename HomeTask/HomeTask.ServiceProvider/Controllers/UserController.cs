using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeTask.ServiceProvider.Controllers
{
    public class UserController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Profile()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("SignIn", "Auth");
            else
                return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeTask.Models;
using Microsoft.AspNetCore.Authorization;

namespace HomeTask.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //if (!User.Identity.IsAuthenticated)
            //    //return Redirect("https://accounts.matrix42.com/issue/oauth2/authorize?client_id=935dcf23-ebf4-4ea1-b7de-07daf7b736f5&scope=urn%3a02676309-9d5e-424d-8c2b-363a07e39afb&redirect_uri=https%3a%2f%2flocalhost%3a44341%2fHome%2fIndex&response_type=token");
            //    return Redirect("https://accounts.matrix42.com/issue/oauth2/authorize?client_id=935dcf23-ebf4-4ea1-b7de-07daf7b736f5&scope=urn%3a02676309-9d5e-424d-8c2b-363a07e39afb&redirect_uri=https%3a%2f%2f192.168.56.1%3a44341%2fHome%2fIndex&response_type=token");
            //else
                return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

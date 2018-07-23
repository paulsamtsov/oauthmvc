using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HomeTask.ServiceProvider.BL.BusinessManagers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HomeTask.ServiceProvider.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration cfg)
        {
            _configuration = cfg;
        }


        [HttpGet]
        [AllowAnonymous]
        [ActionName("Profile")]
        public async Task<ActionResult> ProfileData()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("SignIn", "Auth");
            else
            {
                var token = await HttpContext.GetTokenAsync("Cookies", "access_token");
                var profileClient = new ProfileDataClient(
                    token,
                    _configuration.GetSection("ProfileUrl").Value);
                var OrdersClient = new OrdersDataClient(
                    token,
                    _configuration.GetSection("OrdersBaseUrl").Value);

                var profileData = await profileClient.GetProfileDataAsync();
                profileData.Roles = GetRolesFromUserContext(HttpContext.User.Identity as ClaimsIdentity);
                profileData.Orders = (await OrdersClient.GetOrders()).ToList();

                ViewBag.ProfileData = profileData;

                return View("ProfileData");
            }
        }
        
        [NonAction]
        private List<string> GetRolesFromUserContext(ClaimsIdentity identity)
        {
            if (identity == null)
                throw new ArgumentNullException("No identity");

            return identity.Claims
                .Where(t => t.Type == ClaimTypes.Role)
                .Select(t => t.Value)
                .ToList<string>();
        }
    }
}
using HomeTask.ServiceProvider.BL.Interfaces;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Security;

namespace HomeTask.ServiceProvider.Controllers
{
    [Authorize]
    public class AuthController : Controller
    {
        private readonly string _authUrl;
        private readonly string _clientId;
        private readonly string _scope;
        private readonly string _redirectUrl;
        private readonly string _certificateFilePath;

        private readonly IBaseAuthenticationManager _manager;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        public AuthController(IBaseAuthenticationManager manager)
        {
            _manager = manager ?? throw new ArgumentNullException("Invalid authentication manager");

            _authUrl = ConfigurationManager.AppSettings["Authentication:Url"];
            _clientId = ConfigurationManager.AppSettings["Authentication:ClientId"];
            _scope = HttpUtility.UrlEncode(ConfigurationManager.AppSettings["Authentication:Scope"]);
            _certificateFilePath = HostingEnvironment.MapPath(Path.Combine("/App_Data", ConfigurationManager.AppSettings["CertificateName"]));
        }

        [HttpGet]
        [AllowAnonymous]
        [ActionName("SignIn")]
        public ActionResult AquireAuthenticationToken()
        {

            return Redirect(_manager.CreateAuthenticationUrl(_authUrl, _clientId, _scope, GetRedirectUrl()));
        }

        [HttpGet]
        [AllowAnonymous]
        [ActionName("TokenRedirect")]
        public ActionResult ValidateAuthToken(string access_token)
        {
            if (string.IsNullOrEmpty(access_token))
                return new HttpStatusCodeResult(400, "Invalid token");

            IPrincipal principal = _manager.ValidateAuthenticationToken(access_token, _certificateFilePath);

            if (principal != null)
            {
                AuthenticationManager.SignIn(new AuthenticationProperties()
                {
                    IsPersistent = true
                },
                principal.Identity as ClaimsIdentity);
            }

            return RedirectToAction("Profile", "User");
        }

        [HttpGet]
        [ActionName("SignOut")]
        public ActionResult SignOut()
        {
            _manager.SignOut();

            return RedirectToAction("Profile", "User");
        }

        [NonAction]
        private string GetRedirectUrl()
        {
            return HttpUtility.UrlEncode($"{Request.Url.Scheme}://{Request.Url.Authority}/Auth/TokenRedirect");
        }


    }
}
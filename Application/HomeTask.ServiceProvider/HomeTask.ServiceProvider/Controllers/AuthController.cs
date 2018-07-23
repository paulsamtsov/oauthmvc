using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using HomeTask.ServiceProvider.BL.Interfaces.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HomeTask.ServiceProvider.Controllers
{
    public class AuthController : Controller
    {
        private readonly string _authUrl;
        private readonly string _clientId;
        private readonly string _scope;
        private readonly string _certificateFilePath;

        private readonly IBaseAuthenticationManager _manager;

        public AuthController(IBaseAuthenticationManager manager, IConfiguration configuration, IHostingEnvironment env)
        {
            _manager = manager ?? throw new ArgumentNullException("Invalid authentication manager");

            _authUrl = configuration.GetSection("Authentication:Url").Value;
            _clientId = configuration.GetSection("Authentication:ClientId").Value;
            _scope = HttpUtility.UrlEncode(configuration.GetSection("Authentication:Scope").Value);
            _certificateFilePath = Path.Combine(env.ContentRootPath, "App_Data", configuration.GetSection("CertificateName").Value);
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
        [ActionName("TokenCallback")]
        public ActionResult ValidateAuthToken(string access_token)
        {
            if (string.IsNullOrEmpty(access_token))
                return BadRequest("Invalid token");

            IPrincipal principal = _manager.ValidateAuthenticationToken(access_token, _certificateFilePath);

            if (principal != null)
            {
                var tokens = new List<AuthenticationToken>()
                {
                    new AuthenticationToken()
                    {
                        Name = "access_token",
                        Value = access_token
                    }
                };

                var prop = new Microsoft.AspNetCore.Authentication.AuthenticationProperties();
                prop.IsPersistent = true;
                prop.StoreTokens(tokens);

                HttpContext.SignInAsync(principal as ClaimsPrincipal, prop);
            }

            return RedirectToAction("Profile", "User");
        }

        [NonAction]
        private string GetRedirectUrl()
        {
            return HttpUtility.UrlEncode($"{Request.Scheme}://{Request.Host}/Auth/TokenCallback");
        }
    }
}
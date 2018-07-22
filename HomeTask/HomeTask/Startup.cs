using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeTask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication()
               .AddOAuth("matrix", options =>
               {
                   options.AuthorizationEndpoint = Configuration["Authentication:Authority"];
                   options.ClientId = Configuration["Authentication:Audience"];
                   options.CallbackPath = "/Home/GetToken";
                   options.TokenEndpoint = "";
               });

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddCookie()
            //.AddJwtBearer(options =>
            //{
            //    options.Authority = Configuration["Authentication:Authority"];
            //    options.Audience = Configuration["Authentication:Audience"];
            //    options.Events = new JwtBearerEvents();
            //    options.Events.OnTokenValidated = context =>
            //    {
            //        var accessToken = context.SecurityToken as JwtSecurityToken;
            //        if (accessToken != null)
            //        {
            //            ClaimsIdentity identity = context.Principal.Identity as ClaimsIdentity;
            //            if (identity != null)
            //            {
            //                identity.AddClaim(new Claim("access_token", accessToken.RawData));
            //            }
            //        }
            //        return Task.CompletedTask;
            //    };
            //});

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();


            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

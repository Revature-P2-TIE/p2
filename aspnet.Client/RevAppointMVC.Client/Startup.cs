using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Okta.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace RevAppoint.Client
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
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = OktaDefaults.MvcAuthenticationScheme;
                })
                .AddCookie()
                .AddOktaMvc(new OktaMvcOptions
                {
                    // Replace these values with your Okta configuration
                    // OktaDomain = Configuration["oktaDomain"],
                    // ClientId = Configuration["oktaClient"],
                    // ClientSecret = Configuration["oktaSecret"]
                    OktaDomain = "https://dev-08857242.okta.com",
                    ClientId = "0oa4ymxczHOJFduIw5d6",
                    ClientSecret = "eqUvBphKKXvsterW4DO4BVA7Hu0tUQm_mDYXAExa"
                });
            services.AddControllersWithViews();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // app.UseExceptionHandler("/Home/Error");
                app.UseDeveloperExceptionPage();
                // // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                    // name: "default",
                    // pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

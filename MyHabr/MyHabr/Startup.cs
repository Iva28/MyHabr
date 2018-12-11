using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyHabr.Models;
using MyHabr.Services;

namespace MyHabr
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();


            services.AddDbContext<HabrDbContext>(
                options =>
                {
                    string connstr = configuration.GetConnectionString("HabrConnection");
                    options.UseSqlServer(connstr);
                    options.UseLazyLoadingProxies();
                }
                );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routeBuilder => {
                routeBuilder.MapRoute(
                    name: "userposts",
                    template: "posts/{id:int}",
                    defaults: new { controller = "Post", action = "PostInfo" }
                    );
                routeBuilder.MapRoute(
                   name: "user",
                   template: "users/{id:int}",
                   defaults: new { controller = "User", action = "Info" }
                   );
                routeBuilder.MapRoute(
                  name: "login",
                  template: "/login",
                  defaults: new { controller = "User", action = "Login" }
                  );
                routeBuilder.MapRoute(
                  name: "logot",
                  template: "/logout",
                  defaults: new { controller = "User", action = "Logout" }
                  );
                routeBuilder.MapRoute(
                    "default",
                    "{controller=Post}/{action=All}"
                    );
            });

            app.Run(async (context) => {
                await context.Response.WriteAsync("NOT FOUND");
            });
        }
    }
}

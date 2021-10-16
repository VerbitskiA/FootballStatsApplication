using FootballStatsApplication.BL.Interfaces;
using FootballStatsApplication.BL.Services;
using FootballStatsApplication.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballStatsApplication.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                   .AddCookie(options => //CookieAuthenticationOptions
                {
                       options.LoginPath = new PathString("/Auth/Index");
                   });
            services.AddTransient<ILeagueService, LeagueService>();
            services.AddTransient<IPlaceService, PlaceService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();    // ��������������
            app.UseAuthorization();     // �����������
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}

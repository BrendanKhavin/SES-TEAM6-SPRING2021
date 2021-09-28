using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PROJ.Models;
using PROJ.Interface;
using PROJ.Repository;

using Microsoft.Extensions.Options;
using PROJ.Services;
using Microsoft.AspNetCore.Identity;

namespace PROJ
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


            //MongoDB Services. Need to figure out if these should be here. 
            //Start of MongoDB Addition
            services.Configure<MyDatabaseSettings>(Configuration.GetSection(nameof(MyDatabaseSettings)));
            services.AddSingleton<IMyDataBaseSettings>(sp =>
            sp.GetRequiredService<IOptions<MyDatabaseSettings>>().Value);

            

            services.AddSingleton<DatabaseServices>();
            services.AddSingleton<ICompletedSubjectsRepository, CompletedSubjectsRepository>();
            services.AddSingleton<ISubjectRepository, SubjectRepository>();
            services.AddControllers();
            //End of MongoDB Additions

            //Identity
            // var MongoDBSettings = new MyDatabaseSettings();
            var mongoDbSettings = Configuration.GetSection(nameof(MyDatabaseSettings)).Get<MyDatabaseSettings>();
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>(mongoDbSettings.ConnectionString, mongoDbSettings.DatabaseName);

            //Controller 
            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ProjApp/dist";
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

           

            app.UseRouting();

            //Authentication
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ProjApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}

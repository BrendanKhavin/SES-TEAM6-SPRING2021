using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //Do something here to get the subject data and show it on the data page. 
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv//13559048@student.uts.edu.au:<password>@ses2a.wla5p.mongodb.net/SES2AretryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("SES2A");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

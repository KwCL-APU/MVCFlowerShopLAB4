using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//last library should link to your seeddata class model because initialize method inside the class
using MVCFlowerShop.Models;

namespace MVCFlowerShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            var host = CreateWebHostBuilder(args).Build();

            //make scope of running processes
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try //link with method process and make error handling
                {
                    var context = services.GetRequiredService<MVCFlowerShopContext>();
                    context.Database.Migrate();
                    SeedData.Initialize(services);
                }
                catch(Exception Ex) // make a error log if error
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(Ex, "An error occured seeding the DB!");
                }
                host.Run();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

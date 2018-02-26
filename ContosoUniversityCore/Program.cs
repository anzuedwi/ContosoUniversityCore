using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using ContosoUniversityCore.Data;
using Microsoft.AspNetCore.Identity;
using ContosoUniversityCore.Models;

namespace ContosoUniversityCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var schoolContext = services.GetRequiredService<SchoolContext>();
                    var roleManager = services.GetService<RoleManager<IdentityRole>>();
                    var userManager = services.GetService<UserManager<ApplicationUser>>();
                    var dbInitializedLogger = services.GetRequiredService<ILogger<DbInitializer>>();

                    DbInitializer.Initialize(schoolContext, roleManager, userManager);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

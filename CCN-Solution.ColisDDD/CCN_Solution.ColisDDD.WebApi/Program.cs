using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Domain.Entities;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Contexts;
using CCN_Solution.ColisDDD.Infrastructure.Persistence.Seeds;

namespace CCN_Solution.ColisDDD.WebApi
{
    public class Program
    {
        public async static Task Main(string[] args)
        {

            //Read Configuration from appSettings
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //Initialize Logger
            // var logger = NLogBuilder.ConfigureNLog(String.Concat(config["PathNLogConfig"], "nlog.config")).GetCurrentClassLogger();

            //Initialize Logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var agence = DbInitializer.Seed(context);//<---Do your seeding here

                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<Role>>();
                    // Use Seeds
                    await DefaultRoles.SeedAsync(userManager, roleManager);
                    await DefaultSuperAdmin.SeedAsync(userManager, roleManager, agence);
                    await DefaultBasicUser.SeedAsync(userManager, roleManager, agence);
                    Log.Information("Finished Seeding Default Data");
                    Log.Information("Application Starting");
                }
                catch (Exception ex)
                {
                    Log.Warning(ex.Message + ": \n" + ex.InnerException?.Message + ": " + " \nAn error occurred seeding the DB");
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            }
            host.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog() //Uses Serilog instead of default .NET Logger
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

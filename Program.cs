using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SbornikBackend.Services;

namespace SbornikBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PostNotificationService.InitializeFirebaseApp();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
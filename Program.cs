using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SbornikBackend.DataAccess;

namespace SbornikBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseNpgsql("Host=localhost;Port=5432;Database=db_sbornik;Username=postgres;Password=sarang")
                .Options;
            using (ApplicationContext db = new ApplicationContext(options))
            {
                /*Faculty f = new Faculty {Id = 3, Name = "Истфак", Info = "Наш любимый истфак!", HashtagsId = {1, 2, 3}};
                db.Faculties.Add(f);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");*/

                //Hashtag hashtag1 = new Hashtag {Id = 1, Name = "мехмат"};
                //Hashtag hashtag2 = new Hashtag {Id = 2, Name = "физфак"};
                //db.SaveChanges();
                //var hashtags = db.Hashtags.ToList();
                /*foreach (Hashtag h in hashtags)
                {
                    Console.WriteLine($"{h.Id}   {h.Name}");
                }*/
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
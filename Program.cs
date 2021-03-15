using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
            using (ApplicationContext db = new ApplicationContext())
            {
                /*Hashtag hashtag1 = new Hashtag {Id = 1, Name = "мехмат"};
                Hashtag hashtag2 = new Hashtag {Id = 2, Name = "физфак"};
                db.Hashtags.Add(hashtag1);
                db.Hashtags.Add(hashtag2);*/
                db.SaveChanges();
                var hashtags = db.Hashtags.ToList();
                Console.WriteLine("Объекты успешно сохранены");
                foreach (Hashtag h in hashtags)
                {
                    Console.WriteLine($"{h.Id}   {h.Name}");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AspMultiTenantCommentAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //using (var db = new DBContext())
            //{

            //    var product = new Product() { Price = 100, Description = "Movie" };
            //    db.Products.Add(product);
            //    db.SaveChanges();
            //    foreach (var p in db.Products)
            //    {
            //        Console.WriteLine("{0} {1} {2}", p.ProductId, p.Description, p.Price);
            //    }

            //}
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

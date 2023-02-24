using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LigamaniaCoreApp
{
    public static class Program
    {
        ///Probando cambios con GIT
        public static void Main(string[] args)
        {
            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error de sistema. Póngase en contacto con el administrador");
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    // clear default logging providers
                    logging.ClearProviders();

                    // add built-in providers manually, as needed 
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddEventSourceLogger();
                });
        //public static void Main(string[] args)
        //{
        //    var webHost = new WebHostBuilder()
        //        .UseKestrel()
        //        .UseContentRoot(Directory.GetCurrentDirectory())
        //        .ConfigureAppConfiguration((hostingContext, config) =>
        //        {
        //            var env = hostingContext.HostingEnvironment;
        //            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //                  .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
        //                      optional: true, reloadOnChange: true);
        //            config.AddEnvironmentVariables();
        //        })
        //        .ConfigureLogging((hostingContext, logging) =>
        //        {
        //            // Requires `using Microsoft.Extensions.Logging;`
        //            logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        //            logging.AddConsole();
        //            logging.AddDebug();
        //            logging.AddEventSourceLogger();
        //        })
        //        .UseStartup<Startup>()
        //        .Build();

        //    webHost.Run();
        //}
    }
}

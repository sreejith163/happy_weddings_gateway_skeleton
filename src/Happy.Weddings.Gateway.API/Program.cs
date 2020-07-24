using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Happy.Weddings.Gateway.API
{
    /// <summary>
    /// Program starts here
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates the host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .ConfigureAppConfiguration((context, builder) =>
                    {
                        var env = context.HostingEnvironment;

                        builder.AddJsonFile("appsettings.json",
                                     optional: true, reloadOnChange: true)
                               .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                                     optional: true, reloadOnChange: true);
                    }).UseSerilog();
                });
    }
}

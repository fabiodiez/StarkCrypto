using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StarkCrypto.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace StarkCrypto.WR
{
    public class Program
    {

        public static void Main(string[] args)
        {
           
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>            
            Host.CreateDefaultBuilder(args)                
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddDbContext<DataContext>(opt => opt.UseMySQL("server=127.0.0.1;user=root;password=Olimpo15#;database=starkcrypto"), ServiceLifetime.Singleton);
                    //services.AddDbContext<DataContext>(opt => opt.UseMySQL(Environment.GetEnvironmentVariable("ConnectionStrings:Default")), ServiceLifetime.Singleton);                    
                   // services.AddTransient<DbContext, DataContext>();

                });            
    }
}

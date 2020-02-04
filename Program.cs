using System;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace autofac_does_not_dispose
{
    public class Program
    {
        public static readonly MyDisposable MyDisposable = new MyDisposable();

        public static void Main()
        {
            Host
                .CreateDefaultBuilder()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .Build()
                .Run();
            if (MyDisposable.WasDisposed)
                Console.WriteLine("Was disposed");
            else
                Console.WriteLine("Was not disposed");
        }
    }
}

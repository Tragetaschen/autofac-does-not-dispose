using System.Threading;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace autofac_does_not_dispose
{
    public class Startup
    {
        private Timer t;

        public void ConfigureServices(IServiceCollection services) { }
        public void ConfigureContainer(ContainerBuilder builder)
            // Does not work:
            //=> builder.RegisterInstance(Program.MyDisposable);
            // Does work:
            => builder.RegisterInstance(Program.MyDisposable).AutoActivate();

        public void Configure(
            IApplicationBuilder app,
            IHostApplicationLifetime hostApplicationLifetime
        )
        {
            app.Run(context => context.Response.WriteAsync("Hello World!"));
            t = new Timer(_ => hostApplicationLifetime.StopApplication(), null, 5_000, -1);
        }
    }
}

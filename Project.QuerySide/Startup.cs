using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.Bootstrap;

namespace Project.QuerySide
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public HostConfig HostConfig { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddControllersAsServices();

            HostConfig = new HostConfig();
            Configuration.Bind("HostConfig", HostConfig);
            services.AddSingleton(HostConfig);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddModule(HostConfig.DBConnection);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

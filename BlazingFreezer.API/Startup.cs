using BlazingFreezer.API.Models;
using BlazingFreezer.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlazingFreezer.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FreezerDataContext>(options =>
                options.UseNpgsql("Host=localhost;Database=freezer-dev;Username=dev-user;Password=p@ssw0rd"));
            services.AddCors(o =>
            {
                o.AddPolicy("AllowEverything",
                    builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
            });
            services.AddGrpc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseCors("AllowEverything");
            app.UseRouting();
            app.UseGrpcWeb();
            app.UseEndpoints(endpoints => endpoints.MapGrpcService<FreezerResolverService>().EnableGrpcWeb());
        }
    }
}
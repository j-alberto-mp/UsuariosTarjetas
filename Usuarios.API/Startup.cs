using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;
using Usuarios.Core.Contratos.Factories;
using Usuarios.Core.Middlewares;
using Usuarios.Core.Profiles;
using Usuarios.Repositorios;
using Usuarios.Servicios;
using Usuarios.WorkedServices;

namespace Usuarios.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<UsuariosContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Connection"))
            );

            services.AddAutoMapper(a => a.AddProfile<GeneralProfile>(), typeof(Startup));

            services.AddHostedService<ServicioGeneraTarjeta>();

            services.AddScoped<IServiceFactory, ServiceFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"Clientes v1",
                    Version = "v1",
                    Description = "Clientes API"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clientes API v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<URLMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from here");
            });
        }

        private async Task BasicTest(HttpContext context)
        {
            await context.Response.WriteAsync("TEST");
        }
    }
}
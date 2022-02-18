using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkConVariosRepositorios.DA.Contexts;
using UnitOfWorkConVariosRepositorios.DA.Repositories;
using UnitOfWorkConVariosRepositorios.DA.UoW;

namespace UnitOfWorkConVariosRepositorios
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Prueba UoW", Version = "1.0" });
                //c.IncludeXmlComments(string.Format(@"IntegracionLezica.API.xml", System.AppDomain.CurrentDomain.BaseDirectory));


            });


            string connectionString = Configuration.GetSection("ConnectionStrings").GetSection("DbContext").Value;
            services.AddDbContext<IAplicativoDbContext, AplicativoDbContext>(options => options.UseSqlServer(connectionString));


            //services.AddTransient<IAutosRepository, AutosRepository>();
            //services.AddTransient<IPersonasRepository, PersonasRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BasicAuth v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

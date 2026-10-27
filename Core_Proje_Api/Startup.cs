using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Core_Proje_Api
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

            services.AddSwaggerGen(c => // <<< BURASI EKLENDÝ
            { // <<< BURASI EKLENDÝ
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Core_Proje_Api", Version = "v1" }); // <<< BURASI EKLENDÝ
            }); // <<< BURASI EKLENDÝ
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // 2. EKLENECEK KISIM:
                app.UseSwagger(); // <<< BURASI EKLENDÝ
                app.UseSwaggerUI(c => // <<< BURASI EKLENDÝ
                { // <<< BURASI EKLENDÝ
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core_Proje_Api v1"); // <<< BURASI EKLENDÝ
                }); // <<< BURASI EKLENDÝ
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

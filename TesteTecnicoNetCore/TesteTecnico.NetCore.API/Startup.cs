using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using TesteTecnico.NetCore.API.Configuration;

namespace TesteTecnico.NetCore.API
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var builer = new ConfigurationBuilder()
                  .SetBasePath(env.ContentRootPath)
                  .AddJsonFile("appsettings.json", true, true)
                  .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                  .AddEnvironmentVariables();

            Configuration = builer.Build();
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson(options =>
                       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContextConfig(Configuration); // In DbContextConfig
            services.AddDependencyInjectConfig(Configuration); // In DependencyInjectConfig
           

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Teste Tecníco com .Net Core e Angular", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TesteTecnico.NetCore.API v1"));

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

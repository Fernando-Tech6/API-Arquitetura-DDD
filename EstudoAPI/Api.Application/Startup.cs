using Api.CrossCutting.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application
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
            ConfigureService.ConfigureDependenciesService(services); //Necessario passar a classe e o metodo para habilitar a injeção
            ConfigureRepository.ConfigureDependenciesRepository(services);

            services.AddControllers();

            /*Swagger*/
            services.AddSwaggerGen(t =>
           {
               //t.SwaggerDoc("")
           });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            /*Swagger. É passado o endpoint para o swagger + o nome da applicação*/
            app.UseSwagger();
            app.UseSwaggerUI(t =>
            {
                t.SwaggerEndpoint("/swagger/v1/swagger.json", "Estudo API + DDD");
                t.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

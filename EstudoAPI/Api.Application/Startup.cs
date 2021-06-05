using System;
using Api.CrossCutting.DependencyInjection;
using Api.CrossCutting.JwtInjection;
using Api.CrossCutting.Mappings;
using Api.Data.Context;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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

            /*Criar uma configuração para o automapper e adicionar os mapeamentos do dtos*/
            var config = new AutoMapper.MapperConfiguration(conf =>
            {
                conf.AddProfile(new DtoToModelProfile());
                conf.AddProfile(new EntityToDtoProfile());
                conf.AddProfile(new ModelToEntityProfile());
            }
            );
            /*Injeção de dependencia do automapper*/
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();

            /*Swagger*/
            services.AddSwaggerGen(t =>
           {
               t.SwaggerDoc("v1", new OpenApiInfo
               {        /*Pode criar documentos com informações sobre a api*/
                   Version = "v1",
                   Title = "Estudo API + DDD",
                   Description = "Arquitetura DDD",
                   TermsOfService = new Uri("hht://adicionaalgumsite"),
                   Contact = new OpenApiContact
                   {
                       Name = "Seu Nome",
                       Email = "seuemail.com",
                       Url = new Uri("http://site.com")
                   }
               });
           });

            /*Injeção do jwt*/
            ConfigureJwt.JwtDependecy(services);

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

            app.UseAuthentication();  //Autenticando o token

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

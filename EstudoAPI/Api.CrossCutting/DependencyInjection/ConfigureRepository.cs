using Api.Data.Repository;
using Api.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {   /*Necessário configurar a injeção de dependencia do repositorio e string de conexão*/
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<ILoginRepository, LoginRepository>();


            // /*string de conexão - Necesário para a a camada application não ter acesso direto*/
            // var conexao = "Host=localhost;Database=apiddd;Username=postgres;Password=Ferd@91";
            // serviceCollection.AddDbContext<ApplicationDbContext>(op =>
            // op.UseNpgsql(conexao));  /*SÓ SERÁ UTILZIADA PARA MANIPULAR O BANCO EM TEMPO DE DESENVOLVIMENTO*/
        }


    }
}

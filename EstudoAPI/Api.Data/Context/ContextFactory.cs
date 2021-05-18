using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {  /*Será criado para executar em tempo de design o banco de dados
        Herdando de uma classe do pacote do entity..Design
        Será colocado e Configurado a string de conexão.
       */
        public ApplicationDbContext CreateDbContext(string[] args)
        {   //String de conexão
            var connectionString = "Host=localhost;Database=CleanArch;Username=apiddd;Password=Ferd@91";
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}

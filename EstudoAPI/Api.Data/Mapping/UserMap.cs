using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{   /*Irá realizar o mapeamento antes de criar o banco de dados*/
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User"); //Criando o Nome da Tabela

            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.Email).IsUnique();  // Para não deixar gravar e-mail repetido na base de dados.

            builder.Property(t => t.Email).HasMaxLength(100);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(60); //Obrigando a criação e estabelecendo no maximo 60 caracteres
        }
    }
}

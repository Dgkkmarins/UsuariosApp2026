using ClientesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesApp.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento ORM para a entidade Cliente.
    /// Essa classe é responsável por configurar as propriedades da entidade Cliente, 
    /// como chaves primárias, relacionamentos e outras configurações 
    /// de mapeamento para o banco de dados.
    /// </summary>
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //Nome da tabela
            builder.ToTable("CLIENTES");

            //Chave primária
            builder.HasKey(c => c.Id);

            //Propriedades / campos da tabela
            builder.Property(c => c.Id).HasColumnName("ID");
            builder.Property(c => c.Nome).HasColumnName("NOME").HasMaxLength(150).IsRequired();
            builder.Property(c => c.Cpf).HasColumnName("CPF").HasMaxLength(11).IsRequired();
            builder.Property(c => c.Email).HasColumnName("EMAIL").HasMaxLength(50).IsRequired();
            builder.Property(c => c.Telefone).HasColumnName("TELEFONE").HasMaxLength(20).IsRequired();
            builder.Property(c => c.DataCadastro).HasColumnName("DATACADASTRO").IsRequired();
            builder.Property(c => c.Nivel).HasColumnName("NIVEL").IsRequired();
            builder.Property(c => c.Status).HasColumnName("STATUS").IsRequired();

            //Outras configurações
            builder.HasIndex(c => c.Cpf).IsUnique(); //CPF deve ser único
        }
    }
}

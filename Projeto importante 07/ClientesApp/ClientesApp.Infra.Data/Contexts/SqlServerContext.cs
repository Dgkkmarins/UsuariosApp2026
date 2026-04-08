using ClientesApp.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesApp.Infra.Data.Contexts
{
    /// <summary>
    /// Classe de contexto para conexao com o banco de dados sql server 
    /// e para adicionar as classes de mapeamento de entidades do projeto
    /// </summary>
    public class SqlServerContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDClientesApp;Integrated Security=True;");
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
        }
        }
}

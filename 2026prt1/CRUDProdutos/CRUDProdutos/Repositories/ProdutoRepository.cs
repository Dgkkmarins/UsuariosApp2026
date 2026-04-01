using CRUDProdutos.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDProdutos.Repositories
{
    public class ProdutoRepository
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDProdutos;Integrated Security=True;";

        public void Inserir(Produto produto)
        {
            var query = @"
                INSERT INTO PRODUTOS(ID, NOME, PRECO, QUANTIDADE, DATAHORACADASTRO)
                VALUES(@Id, @Nome, @Preco, @Quantidade, @DataHoraCadastro)
            ";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, produto);
            }
        }

        public void Alterar(Produto produto)
        {
            var query = @"
                UPDATE PRODUTOS
                SET NOME = @Nome, PRECO = @Preco, QUANTIDADE = @Quantidade
                WHERE ID = @Id
            ";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, produto);
            }
        }

        public void Excluir(Guid id)
        {
            var query = @"
                DELETE FROM PRODUTOS
                WHERE ID = @Id
            ";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, new { Id = id });
            }
        }

        public List<Produto> Consultar()
        {
            var query = @"
                SELECT ID, NOME, PRECO, QUANTIDADE, DATAHORACADASTRO
                FROM PRODUTOS
            ";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Produto>(query).ToList();
            }
        }

        public Produto? ObterPorId(Guid id)
        {
            var query = @"
                SELECT ID, NOME, PRECO, QUANTIDADE, DATAHORACADASTRO
                FROM PRODUTOS
                WHERE ID = @Id
            ";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<Produto>(query, new { Id = id });
            }
        }
    }
}
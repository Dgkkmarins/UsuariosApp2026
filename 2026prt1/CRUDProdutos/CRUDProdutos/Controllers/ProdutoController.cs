using CRUDProdutos.Entities;
using CRUDProdutos.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDProdutos.Controllers
{
    /// <summary>
    /// Controlador para implementar os fluxos de entrada de dados
    /// do usuário para cadastrar, alterar, consultar e excluir
    /// produtos no sistema.
    /// </summary>
    public class ProdutoController
    {
        private ProdutoRepository produtoRepository = new ProdutoRepository();

        public void GerenciarProdutos()
        {
            Console.WriteLine("\nSISTEMA DE CONTROLE DE PRODUTOS:\n");
            Console.WriteLine("\t(1) CADASTRAR PRODUTO");
            Console.WriteLine("\t(2) ATUALIZAR PRODUTO");
            Console.WriteLine("\t(3) EXCLUIR PRODUTO");
            Console.WriteLine("\t(4) CONSULTAR PRODUTOS");

            Console.Write("\nINFORME A OPÇÃO DESEJADA: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": CadastrarProduto(); break;
                case "2": AtualizarProduto(); break;
                case "3": ExcluirProduto(); break;
                case "4": ConsultarProdutos(); break;
                default:
                    Console.WriteLine("\nOPÇÃO INVÁLIDA!");
                    break;
            }

            Console.Write("\nDESEJA EXECUTAR OUTRA OPERAÇÃO? (S,N): ");
            var confirmacao = Console.ReadLine();

            if (confirmacao.ToUpper().Equals("S"))
            {
                Console.Clear(); //Limpar o console do DOS
                GerenciarProdutos(); //Recursividade
            }
            else
            {
                Console.WriteLine("\nFIM DO PROGRAMA!");
            }
        }

        private void CadastrarProduto()
        {
            Console.WriteLine("\nCADASTRO DE PRODUTO:\n");

            var produto = new Produto();

            Console.Write("NOME DO PRODUTO.........: ");
            produto.Nome = Console.ReadLine();

            Console.Write("PREÇO...................: ");
            produto.Preco = decimal.Parse(Console.ReadLine());

            Console.Write("QUANTIDADE..............: ");
            produto.Quantidade = int.Parse(Console.ReadLine());

            produtoRepository.Inserir(produto);

            Console.WriteLine("\nPRODUTO CADASTRADO COM SUCESSO!");
        }

        private void AtualizarProduto()
        {
            Console.WriteLine("\nATUALIZAÇÂO DE PRODUTO:\n");

            Console.Write("INFORME O ID DO PRODUTO....: ");
            var id = Guid.Parse(Console.ReadLine());

            var produto = produtoRepository.ObterPorId(id);

            if (produto != null)
            {
                Console.Write("NOME DO PRODUTO............: ");
                produto.Nome = Console.ReadLine();

                Console.Write("PREÇO......................: ");
                produto.Preco = decimal.Parse(Console.ReadLine());

                Console.Write("QUANTIDADE.................: ");
                produto.Quantidade = int.Parse(Console.ReadLine());

                produtoRepository.Alterar(produto);

                Console.WriteLine("\nPRODUTO ATUALIZADO COM SUCESSO!");
            }
            else
            {
                Console.WriteLine("\nNENHUM PRODUTO FOI ENCONTRADO.");
            }
        }

        private void ExcluirProduto()
        {
            Console.WriteLine("\nEXCLUSÃO DE PRODUTO:\n");

            Console.Write("INFORME O ID DO PRODUTO....: ");
            var id = Guid.Parse(Console.ReadLine());

            var produto = produtoRepository.ObterPorId(id);

            if (produto != null)
            {
                Console.WriteLine("\tNOME.......: " + produto.Nome);
                Console.WriteLine("\tPREÇO......: " + produto.Preco);
                Console.WriteLine("\tQUANTIDADE.: " + produto.Quantidade);

                Console.Write("\nDESEJA EXCLUIR ESTE PRODUTO? (S,N): ");
                var escolha = Console.ReadLine();

                if (escolha.ToUpper().Equals("S"))
                {
                    produtoRepository.Excluir(id);
                    Console.WriteLine("\nPRODUTO EXCLUIDO COM SUCESSO!");
                }
                else
                {
                    Console.WriteLine("\nEXCLUSÃO CANCELADA!");
                }
            }
            else
            {
                Console.WriteLine("\nNENHUM PRODUTO FOI ENCONTRADO.");
            }
        }

        private void ConsultarProdutos()
        {
            var produtos = produtoRepository.Consultar();

            Console.WriteLine("\nCONSULTA DE PRODUTOS:\n");

            foreach (var item in produtos)
            {
                Console.WriteLine("ID......................: " + item.Id);
                Console.WriteLine("NOME....................: " + item.Nome);
                Console.WriteLine("PREÇO...................: " + item.Preco);
                Console.WriteLine("QUANTIDADE..............: " + item.Quantidade);
                Console.WriteLine("DATA E HORA DE CADASTRO.: " + item.DataHoraCadastro);
                Console.WriteLine("...");
            }
        }
    }
}

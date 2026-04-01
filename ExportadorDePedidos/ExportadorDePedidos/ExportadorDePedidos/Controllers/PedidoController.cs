using ExportadorDePedidos.Entities;
using ExportadorDePedidos.Interfaces;
using ExportadorDePedidos.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExportadorDePedidos.Controllers
{
    /// <summary>
    /// Controlador para capturar os dados do pedido
    /// </summary>
    public class PedidoController
    {
        public static void CapturarPedido()
        {
            var pedido = new Pedido(); //Objeto da classe de entidade

            Console.WriteLine("\nCADASTRO DE PEDIDO:\n");

            //Cliente
            Console.Write("NOME DO CLIENTE................: ");
            pedido.Cliente.Nome = Console.ReadLine() ?? string.Empty;

            Console.Write("CPF DO CLIENTE.................: ");
            pedido.Cliente.Cpf = Console.ReadLine() ?? string.Empty;

            //Itens do pedido
            Console.Write("QUANTIDADE DE ITENS DO PEDIDO..: ");
            var qtdItens = int.Parse(Console.ReadLine() ?? "0");

            for (int i = 1; i <= qtdItens; i++)
            {
                var item = new ItemPedido();

                Console.WriteLine($"\n{i}º ITEM DO PEDIDO:");

                Console.Write("NOME DO PRODUTO................: ");
                item.Produto.Nome = Console.ReadLine() ?? string.Empty;

                Console.Write("PREÇO..........................: ");
                item.Produto.Preco = decimal.Parse(Console.ReadLine() ?? "0");

                Console.Write("QUANTIDADE.....................: ");
                item.Quantidade = int.Parse(Console.ReadLine() ?? "0");

                //Somar ao valor total do pedido
                pedido.Valor += item.Produto.Preco * item.Quantidade;

                //Adicionar o item ao pedido
                pedido.ItensPedido.Add(item);
            }

            //Dados do pedido
            Console.WriteLine("\nDADOS DO PEDIDO:\n");
            Console.WriteLine("\tID...............: " + pedido.Id);
            Console.WriteLine("\tDATA HORA........: " + pedido.DataHora);
            Console.WriteLine("\tVALOR TOTAL......: " + pedido.Valor);
            Console.WriteLine("\tNOME DO CLIENTE..: " + pedido.Cliente.Nome);
            Console.WriteLine("\tCPF DO CLIENTE...: " + pedido.Cliente.Cpf);

            foreach (var item in pedido.ItensPedido)
            {
                Console.WriteLine("\n\tNOME DO PRODUTO..: " + item.Produto.Nome);
                Console.WriteLine("\tPREÇO............: " + item.Produto.Preco);
                Console.WriteLine("\tQUANTIDADE.......: " + item.Quantidade);
            }

            Console.Write("\nCOMO DESEJA EXPORTAR O PEDIDO? (1)XML OU (2)JSON: ");
            var opcao = int.Parse(Console.ReadLine() ?? "0");

            //Criando um objeto da interface
            IPedidoService pedidoService;

            switch (opcao)
            {
                case 1:
                    //Polimorfismo
                    pedidoService = new PedidoServiceXml();
                    break;
                case 2:
                    //Polimorfismo
                    pedidoService = new PedidoServiceJson();
                    break;
                default:
                    Console.WriteLine("\nOPÇÃO INVÁLIDA!");
                    return;
            }

            //Exportar o pedido
            pedidoService.ExportarPedido(pedido);

            Console.WriteLine("\nDADOS GRAVADOS COM SUCESSO!");
        }
    }
}

using ExportadorDePedidos.Entities;
using ExportadorDePedidos.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExportadorDePedidos.Services
{
    /// <summary>
    /// Implementação do serviço de exportação de pedidos para o formato JSON.
    /// </summary>
    public class PedidoServiceJson : IPedidoService
    {
        public void ExportarPedido(Pedido pedido)
        {
            //Serializando o pedido para JSON
            var json = JsonConvert.SerializeObject(pedido, Formatting.Indented);

            //Criando o arquivo JSON na máquina do usuário
            using (var streamWriter = new StreamWriter($"c:\\temp\\pedido_{pedido.Id}.json"))
            {
                //Escrever o conteúdo JSON no arquivo
                streamWriter.WriteLine(json);
            }
        }
    }
}

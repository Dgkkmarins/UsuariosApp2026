using ExportadorDePedidos.Entities;
using ExportadorDePedidos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ExportadorDePedidos.Services
{
    /// <summary>
    /// Implementação do serviço para exportar os dados do pedido em formato XML
    /// </summary>
    public class PedidoServiceXml : IPedidoService
    {
        public void ExportarPedido(Pedido pedido)
        {
            //Serializar os dados do pedido para o formato Xml
            var xml=new XmlSerializer(typeof(Pedido));
            //Criando um arquivo XML para exportar o pedido
            using (var streamWrite = new StreamWriter($"c:\\temp\\pedido_{pedido.Id}.xml"))
            {
                //salvar o pedido no arquivo XMl
                xml.Serialize(streamWrite, pedido);
            }
        }
    }
}

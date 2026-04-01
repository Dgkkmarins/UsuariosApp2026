using ExportadorDePedidos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExportadorDePedidos.Interfaces
{
    public interface IPedidoService
    {
        /// <summary>
        /// Método abstrato para exportar dados de um pedido
        /// </summary>
        public void ExportarPedido(Pedido pedido);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ExportadorDePedidos.Entities
{
    /// <summary>
    /// Modelo de entidade para pedido
    /// </summary>
    public class Pedido
    {
        #region Propriedades

        public Guid Id { get; set; } = Guid.NewGuid();
        public Cliente Cliente { get; set; } = new();
        public DateTime DataHora { get; set; } = DateTime.Now;
        public decimal Valor { get; set; } = decimal.Zero;
        public List<ItemPedido> ItensPedido { get; set; } = new();

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ExportadorDePedidos.Entities
{
    /// <summary>
    /// Modelo de entidade para item de pedido
    /// </summary>
    public class ItemPedido
    {
        #region Propriedades

        public Guid Id { get; set; } = Guid.NewGuid();
        public Produto Produto { get; set; } = new();
        public int Quantidade { get; set; } = 1;

        #endregion
    }
}

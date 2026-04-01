
using System;
using System.Collections.Generic;
using System.Text;

namespace ExportadorDePedidos.Entities
{
    /// <summary>
    /// Modelo de entidade para produto.
    /// </summary>
    public class Produto
    {
        #region Propriedades

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; } = decimal.Zero;

        #endregion
    }
}
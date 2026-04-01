using System;
using System.Collections.Generic;
using System.Text;

namespace ExportadorDePedidos.Entities
{
    /// <summary>
    /// Modelo de entidade para cliente.
    /// </summary>
    public class Cliente
    {
        #region Propriedades

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;

        #endregion
    }
}



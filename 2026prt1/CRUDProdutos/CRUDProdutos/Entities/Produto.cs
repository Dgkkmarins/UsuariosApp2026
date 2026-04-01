using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDProdutos.Entities
{
    ///  <summary>
    ///  Modelo de Entidade para o Produto
    ///  </summary>
    public class Produto
    {
        #region Propriedades
        public Guid Id { get; set; }= Guid.NewGuid();
        public string Nome { get; set; }= string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataHoraCadastro { get; set; } = DateTime.Now;

        #endregion
    }
}

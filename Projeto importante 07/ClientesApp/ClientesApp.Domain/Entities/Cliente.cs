using ClientesApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesApp.Domain.Entities
{
    /// <summary>
    /// Modelo de entidade para Cliente
    /// </summary>
    public class Cliente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public NivelCliente Nivel { get; set; }
        public StatusCliente Status { get; set; } = StatusCliente.Ativo;
    }
}
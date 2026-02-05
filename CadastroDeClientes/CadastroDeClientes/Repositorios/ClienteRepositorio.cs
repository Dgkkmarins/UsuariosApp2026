using CadastroDeClientes.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroDeClientes.Repositorios
{
    public class ClienteRepositorio
    {
        public void Exportar(Cliente cliente)
        {
            var streamwriter = new StreamWriter
                ("D:\\_Diego\\temp\\relatorio.txt", true);
            //Escrevendo os dados no arquivo
            streamwriter.WriteLine ("****** Clientes ******");
            streamwriter.WriteLine (cliente.Id);
            streamwriter.WriteLine (cliente.Nome);
            streamwriter.WriteLine (cliente.Email);
            streamwriter.WriteLine (cliente.Telefone);
            streamwriter.WriteLine (cliente.DataHoraCadastro);
            //Fechando o arquivo
            streamwriter.Close();

        }
    }
}

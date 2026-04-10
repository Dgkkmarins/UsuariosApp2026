using ClientesApp.Domain.Entities;
using ClientesApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientesApp.Infra.Data.Repositories
{
    /// <summary>
    /// Repositorio para operações de banco de dados com Cliente
    /// </summary>
    public class ClienteRepository
    {
        public void Inserir(Cliente cliente)
        {
            using (var context=new SqlServerContext())
            {
                //Verificar se o cpf do cliente é valido
                if(context.Set<Cliente>().Count(c=>c.Cpf.Equals(cliente.Cpf))>0) 
                { 
                    throw new ApplicationException("CPF informado ja está cadastrado,tente outro.");

                }
                else
                { context.Add(cliente);
                    context.SaveChanges();
                }

            }

        }
    }
}

using CadastroDeClientes.Entidades;
using CadastroDeClientes.Repositorios;
Console.WriteLine("\nSISTEMA DE CADASTRO DE CLIENTES:\n");
Console.WriteLine("\n Entre com os dados do Cliente:\n");
//criando um objeto da classe Cliente
var cliente = new Cliente();
Console.WriteLine("Informe o nome do cliente....:");
cliente.Nome = Console.ReadLine();
Console.WriteLine("Informe o email do cliente...:");
cliente.Email = Console.ReadLine();
Console.WriteLine("Informe o telefone do cliente:");    
cliente.Telefone = Console.ReadLine();
//imprimindo os dados do cliente
Console.WriteLine("\nDados do Cliente:\n");
Console.WriteLine("Id do cliente............"+cliente.Id);
Console.WriteLine("Nome do cliente.........." + cliente.Nome);
Console.WriteLine("Email do cliente........." + cliente.Email);
Console.WriteLine("Telefone do cliente......" + cliente.Telefone);
Console.WriteLine("Data e hora do cadastro.." + cliente.DataHoraCadastro);
//gravando os dados do cliente em um arquivo texto
var clienterepositorio = new ClienteRepositorio();
clienterepositorio.Exportar(cliente);
//pausar o prompt
Console.ReadKey();

//Construir a aplicação ASP.NET usando as configurações necessárias
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//Adiciona suporte para as classes de controle do projeto
builder.Services.AddControllers();

//Configura suporte para a documentação da API
builder.Services.AddOpenApi();

//Configurações do Swagger
builder.Services.AddEndpointsApiExplorer(); //Adiciona suporte para explorar os endpoints da API
builder.Services.AddSwaggerGen(); //gerar a documentação da API usando o Swagger

//Constrói a aplicação com as configurações definidas
var app = builder.Build();

//Verifica se o ambiente atual é de desenvolvimento
if (app.Environment.IsDevelopment())
{
    //Habilitar a interface de usuário para a documentação da API
    app.MapOpenApi();
}

//Configurações do Swagger
app.UseSwagger(); //Habilita o middleware do Swagger para gerar a documentação da API
app.UseSwaggerUI(); //Habilita a interface de usuário do Swagger para visualizar a documentação da API

//Scalar
app.MapScalarApiReference(s => s.WithTheme(ScalarTheme.DeepSpace));

//Habilita o middleware de autorização (controle de acesso)
app.UseAuthorization();

//Mapeia os controles e rotas do projeto
app.MapControllers();

//Executa o projeto
app.Run();

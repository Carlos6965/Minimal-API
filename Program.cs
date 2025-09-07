using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Login",
        Version = "v1",
        Description = "API simples para autenticação de usuário"
    });
});

var app = builder.Build();

// Habilita o Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Login v1");
    c.RoutePrefix = string.Empty; // Swagger será servido na raiz da aplicação
});

// Endpoint de teste
app.MapGet("/", () => "Hello World!");

// Endpoint de login
app.MapPost("/Login", (minimal_api.Dominio.DTOs.LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
    {
        return Results.Ok("Logado com sucesso!");
    }
    else
    {
        return Results.Unauthorized(); // Retorna 401 se credenciais estiverem incorretas
    }
})
.WithName("Login") // Nome para o Swagger
.WithTags("Autenticação"); // Agrupa no Swagger

app.Run();

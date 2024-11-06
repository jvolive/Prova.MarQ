using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Infra;

var builder = WebApplication.CreateBuilder(args);

// Registra o DbContext no container de dependências
builder.Services.AddDbContext<MarqDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

// Configurações do Swagger (se estiver usando)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

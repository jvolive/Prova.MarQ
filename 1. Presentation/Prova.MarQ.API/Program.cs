using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Domain.Interfaces.Helpers;
using Prova.MarQ.Domain.Repositories.Interfaces;
using Prova.MarQ.Domain.Services;
using Prova.MarQ.Domain.Services.Interfaces;
using Prova.MarQ.Infra;
using Prova.MarQ.Infra.Helpers;
using Prova.MarQ.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Registra o DbContext no container de dependências
builder.Services.AddDbContext<MarqDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

// Configurações do Swagger (se estiver usando)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ITimeRecordRepository, TimeRecordRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IPinHelper, PinHelper>();
builder.Services.AddScoped<IRegistrationHelper, RegistrationHelper>();

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

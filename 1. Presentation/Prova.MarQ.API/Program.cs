using Microsoft.EntityFrameworkCore;
using Prova.MarQ.API.Configuration.AutoMapping;
using Prova.MarQ.Domain.Interfaces.Helpers;
using Prova.MarQ.Domain.Repositories.Interfaces;
using Prova.MarQ.Domain.Services;
using Prova.MarQ.Domain.Services.Interfaces;
using Prova.MarQ.Infra;
using Prova.MarQ.Infra.Helpers;
using Prova.MarQ.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MarqDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MarqDb")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMappingProfile));
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ITimeRecordRepository, TimeRecordRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ITimeRecordService, TimeRecordService>();
builder.Services.AddScoped<IPinHelper, PinHelper>();
builder.Services.AddScoped<IRegistrationHelper, RegistrationHelper>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

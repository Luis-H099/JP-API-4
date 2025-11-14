using Modelo.Application;
using Modelo.Application.Interface;
using Modelo.Infra;
using Modelo.Infra.Repositorio;
using Modelo.Infra.Repositorio.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<DbConnectionFactory>();
builder.Services.AddScoped<IAlunoApplication, AlunoApplication>();
builder.Services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
builder.Services.AddHttpClient<ICepService, CepService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using LolWebAPI.Services;
using LolWebApiRest.Data;
using LolWebApiRest.Interfaces;
using LolWebApiRest.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DuoDbContext>(context =>
                 context.UseSqlServer(builder.Configuration.GetConnectionString("DuoDbConnection")));
builder.Services.AddScoped<IAnuncioRepository, AnuncioRepository>();
builder.Services.AddScoped<ILolService, LolService>();
builder.Services.AddScoped<IDuoRepository, DuoRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:4200") // Adicione a origem do cliente Angular
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials(); // Se necessário, permita credenciais
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

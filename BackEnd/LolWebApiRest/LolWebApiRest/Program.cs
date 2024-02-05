using LolWebAPI.Services;
using LolWebApiRest.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILolService, LolService>();

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

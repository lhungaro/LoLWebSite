using Freela.Application;
using Freela.Application.Contratos;
using Freela.Persistence;
using Freela.Persistence.Repository;
using FreelaAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FreelaContext>(context => 
                 context.UseSqlServer(builder.Configuration.GetConnectionString("FreelaDatabase")));
builder.Services.AddScoped<IProjectService , ProjectService>();
builder.Services.AddScoped<IFreelaRepository , FreelaRepository>();
builder.Services.AddScoped<IProjectRepository , ProjectRepository>();
builder.Services.AddScoped<IUserRepository , UserRepository>();
builder.Services.AddScoped<IUserService , UserService>();
//builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling 
//                                 = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(option => option.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()); //funcionar quando der erro de CROS

app.MapControllers();

app.Run();

global using FastEndpoints;
global using FastEndpoints.Security;
global using FluentValidation;
global using MongoDB.Entities;
using FastEndpoints.Swagger;

using MinimalApi.Ioc; 

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc(); // добавление урлов
builder.Services.AddMongo(builder.Configuration["MongoDb"]);
builder.Services.AddAuthenticationJWTBearer(builder.Configuration["JwtSigningKey"]);

var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints();

app.UseOpenApi(); // использование апи 

app.UseSwaggerUi3(c => c.ConfigureDefaults()); // конфигурация 
app.Run();

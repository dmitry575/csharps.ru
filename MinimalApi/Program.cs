global using FastEndpoints;
global using FastEndpoints.Security;
global using FluentValidation;
global using MongoDB.Entities;
using FastEndpoints.Swagger;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc(); // добавление урлов
builder.Services.AddAuthenticationJWTBearer(builder.Configuration["JwtSigningKey"]);

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();

app.UseOpenApi(); // использование апи 

app.UseSwaggerUi3(c => c.ConfigureDefaults());
var settings = MongoClientSettings.FromUrl(MongoUrl.Create(builder.Configuration["MongoDb"]));
await DB.InitAsync(database: "MinimalApi", settings);

app.Run();

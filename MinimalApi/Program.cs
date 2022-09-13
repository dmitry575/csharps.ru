global using FastEndpoints;
using FastEndpoints.Swagger; // добавить swagger

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc(); // добавление урлов

var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints();

app.UseOpenApi(); // использование апи 

app.UseSwaggerUi3(c => c.ConfigureDefaults()); // конфигурация 
app.Run();

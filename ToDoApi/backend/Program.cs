using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Dienste registrieren
builder.Services.AddControllers(); // fügt Controller-Support hinzu
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware konfigurieren
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Controller-Routen aktivieren

app.Run();
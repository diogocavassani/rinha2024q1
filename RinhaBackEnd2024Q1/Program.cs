using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RinhaBackEnd2024Q1.Data;
using RinhaBackEnd2024Q1.Model;
using RinhaBackEnd2024Q1.ViewModels;
using System.ComponentModel;


var builder = WebApplication.CreateBuilder(args);
ConfigurationServices(builder);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var cliente = app.MapGroup("/clientes").WithName("Clientes").WithOpenApi();

cliente.MapPost("/{Id}/transacoes", async (int id, [FromBody] TransacaoViewModel transacao, [FromServices] DataContext db) =>
{
    if (id <= 0 || !db.Clientes.Any(p => p.Id == id))
        return Results.NotFound();


    var cliente = await db.Clientes.Where(p => p.Id == id).FirstAsync();

    if (!cliente.AddTransacao(transacao))
        return Results.UnprocessableEntity();
    
    await db.SaveChangesAsync();
    return Results.Ok(new { cliente.Limite, cliente.Saldo });
});



app.Run();


void ConfigurationServices(WebApplicationBuilder builder)
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<DataContext>(p => p.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

}
internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

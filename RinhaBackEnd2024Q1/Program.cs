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
//try
//{
//    var scope = app.Services.CreateScope();
//    var db = scope.ServiceProvider.GetRequiredService<DataContext>();

//    db.Database.Migrate();
//}
//catch (Exception)
//{

//}


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

var cliente = app.MapGroup("/clientes").WithOpenApi();

cliente.MapPost("/{id}/transacoes", async (int id, TransacaoViewModel transacao, DataContext db) =>
{

    if(!transacao.isValid()) return Results.UnprocessableEntity();


    var cliente = await db.Clientes.Where(p => p.Id == id).FirstOrDefaultAsync();
    if (cliente is null)
        return Results.NotFound();

    var saldos = transacao.Tipo == 'c' ? 
        await db.AtualizarSaldos.FromSqlInterpolated($"SELECT * FROM atualizar_saldo_credito({id}, {(int)transacao.Valor}, {transacao.Descricao})").ToListAsync() :
        await db.AtualizarSaldos.FromSqlInterpolated($"SELECT * FROM atualizar_saldo_debito({id}, {(int)transacao.Valor}, {transacao.Descricao})").ToListAsync();

    if (saldos.FirstOrDefault()?.saldo_atual is null)
            return Results.UnprocessableEntity();
    // if (!cliente.AddTransacao(transacao))
    //     return Results.UnprocessableEntity();
    
    //await db.SaveChangesAsync();
    return Results.Ok(new { cliente.Limite, saldos.FirstOrDefault()?.saldo_atual });
});

cliente.MapGet("{id}/extrato", async (int id, DataContext db) => {
    var cliente = await db.Clientes.FirstOrDefaultAsync(p => p.Id == id);

    if (cliente is null)
       return Results.NotFound();

    var transacoes = await db.Tracacoes.Where(p => p.IdCliente == id).OrderByDescending(p => p.Realizada_em).Take(5).Select(p =>
         new TransacaoExtradoViewModel
         {
             descricao = p.Descricao,
             realizada_em = p.Realizada_em,
             tipo = p.Tipo,
             valor = p.valor
         }
    ).ToListAsync();

    return Results.Ok(new ExtratoViewModel
    {
        saldo = new SaldoViewModel { limite= cliente.Limite, total = cliente.Saldo},
        ultimas_transacoes = transacoes
    });
});

cliente.MapGet("teste", async () => {

    return Results.Ok("API RODANDO");
});


app.Run();


void ConfigurationServices(WebApplicationBuilder builder)
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<DataContext>(p => p.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

}

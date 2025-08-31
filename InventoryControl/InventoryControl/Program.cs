using InventoryControl.Infrastructure;
using InventoryControl.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDb>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Endpoints básicos
app.MapGet("/produtos", async (AppDb db) => await db.Produtos.ToListAsync());

app.MapPost("/produtos", async (Produto p, AppDb db) =>
{
    db.Produtos.Add(p);
    await db.SaveChangesAsync();
    return Results.Created($"/produtos/{p.Id}", p);
});

app.MapPost("/movimentos", async (Movimento m, AppDb db) =>
{
    db.Movimentos.Add(m);
    await db.SaveChangesAsync();
    return Results.Created($"/movimentos/{m.Id}", m);
});

app.MapGet("/alertas", async (AppDb db) =>
    await (from p in db.Produtos
           join min in db.EstoqueMinimo on p.Id equals min.ProdutoId
           let saldo = db.Movimentos.Where(x => x.ProdutoId == p.Id)
               .Sum(x => x.Tipo == "ENTRADA" ? x.Qtd : -x.Qtd)
           where saldo < min.Minimo
           select new { p.Id, p.Nome, Saldo = saldo, min.Minimo }).ToListAsync()
);

app.Run();

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryControl.Infrastructure;

namespace InventoryControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstoqueMinimosController : ControllerBase
{
    private readonly AppDb _db;
    public EstoqueMinimosController(AppDb db) => _db = db;

    // GET api/estoqueminimos/alertas
    [HttpGet("alertas")]
    public async Task<IActionResult> GetAlertas()
    {
        var alertas = await (
            from p in _db.Produtos
            join min in _db.EstoqueMinimo on p.Id equals min.ProdutoId
            let saldo = _db.Movimentos.Where(x => x.ProdutoId == p.Id)
                         .Sum(x => x.Tipo == "ENTRADA" ? x.Qtd : -x.Qtd)
            where saldo < min.Minimo
            select new { p.Id, p.Nome, Saldo = saldo, min.Minimo }
        ).ToListAsync();

        return Ok(alertas);
    }
}

using Microsoft.AspNetCore.Mvc;
using InventoryControl.Infrastructure;
using InventoryControl.Domain;

namespace InventoryControl.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimentosController : ControllerBase
{
    private readonly AppDb _db;
    public MovimentosController(AppDb db) => _db = db;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Movimento m)
    {
        _db.Movimentos.Add(m);
        await _db.SaveChangesAsync();
        return Created($"/api/movimentos/{m.Id}", m);
    }
}

using FluentValidation;
using InventoryControl.Application.DTOs;
using InventoryControl.Application.Services;
using Microsoft.AspNetCore.Mvc;

public class ProdutosController : ControllerBase
{
    private readonly ProdutoService _service;
    private readonly IValidator<ProdutoDto> _validator;
    public ProdutosController(ProdutoService service, IValidator<ProdutoDto> validator)
    { _service = service; _validator = validator; }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProdutoDto dto)
    {
        var val = await _validator.ValidateAsync(dto);
        if (!val.IsValid) return ValidationProblem(val.ToDictionary());
        var novo = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = novo.Id }, novo);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProdutoDto dto)
    {
        var val = await _validator.ValidateAsync(dto);
        if (!val.IsValid) return ValidationProblem(val.ToDictionary());
        var ok = await _service.UpdateAsync(id, dto);
        return ok ? NoContent() : NotFound();
    }
}

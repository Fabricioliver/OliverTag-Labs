using InventoryControl.Application.DTOs;
using InventoryControl.Domain;

namespace InventoryControl.Application.Mappers;

public static class ProdutoMapper
{
    public static ProdutoDto ToDto(this Produto p) =>
        new(p.Id, p.Nome, p.Preco);

    public static Produto ToEntity(this ProdutoDto dto) =>
        new() { Id = dto.Id, Nome = dto.Nome, Preco = dto.Preco, EstoqueMinimo = 0 };

}

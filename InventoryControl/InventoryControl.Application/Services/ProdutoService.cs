using InventoryControl.Application.DTOs;
using InventoryControl.Application.Mappers;
using InventoryControl.Domain;
using InventoryControl.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace InventoryControl.Application.Services;

public class ProdutoService
{
    private readonly AppDb _db;
    public ProdutoService(AppDb db) => _db = db;

    public async Task<List<ProdutoDto>> GetAllAsync()
    {
        var produtos = await _db.Produtos.ToListAsync();
        return produtos.Select(p => p.ToDto()).ToList();
    }

    public async Task<ProdutoDto?> GetByIdAsync(int id)
    {
        var p = await _db.Produtos.FindAsync(id);
        return p?.ToDto();
    }

    public async Task<ProdutoDto> CreateAsync(ProdutoDto dto)
    {
        var entity = dto.ToEntity();
        _db.Produtos.Add(entity);
        await _db.SaveChangesAsync();
        return entity.ToDto();
    }

    public async Task<bool> UpdateAsync(int id, ProdutoDto dto)
    {
        if (id != dto.Id) return false;

        var entity = await _db.Produtos.FindAsync(id);
        if (entity == null) return false;

        entity.Nome = dto.Nome;
        entity.Preco = dto.Preco;

        _db.Entry(entity).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _db.Produtos.FindAsync(id);
        if (entity == null) return false;

        _db.Produtos.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
}

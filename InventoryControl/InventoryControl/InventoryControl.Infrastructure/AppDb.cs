using Microsoft.EntityFrameworkCore;
using InventoryControl.Domain;


namespace InventoryControl.InventoryControl.Infrastructure
{
    using InventoryControl.Domain;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options) { }

        public DbSet<Produto> Produtos => Set<Produto>();
        public DbSet<Movimento> Movimentos => Set<Movimento>();
        public DbSet<EstoqueMinimo> EstoqueMinimo => Set<EstoqueMinimo>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryControl.Domain;

namespace InventoryControl.Infrastructure
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options) { }

        public DbSet<Produto> Produtos => Set<Produto>();
        public DbSet<Movimento> Movimentos => Set<Movimento>();
        public DbSet<EstoqueMinimo> EstoqueMinimo => Set<EstoqueMinimo>();
    }
}

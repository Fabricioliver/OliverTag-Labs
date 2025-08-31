using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain;
public class Movimento
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; } = null!;
    public string Tipo { get; set; } = null!; // ENTRADA/SAIDA
    public decimal Qtd { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}


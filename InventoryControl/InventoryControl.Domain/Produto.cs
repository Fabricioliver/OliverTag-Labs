using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain;
public class Produto
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Nome { get; set; } = null!;
    [Range(0.01, double.MaxValue)]
    public decimal Preco { get; set; }
    public int EstoqueMinimo { get; set; }

}

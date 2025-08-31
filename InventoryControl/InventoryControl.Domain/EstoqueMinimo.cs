namespace InventoryControl.Domain;

public class EstoqueMinimo
{
    public int ProdutoId { get; set; }
    public Produto? Produto { get; set; }
    public decimal Minimo { get; set; }
}

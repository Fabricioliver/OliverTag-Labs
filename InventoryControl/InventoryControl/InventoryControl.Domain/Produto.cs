namespace InventoryControl.InventoryControl.Domain
{
    // backend/InventoryControl.Domain/Produto.cs
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public decimal Preco { get; set; }
        public int EstoqueMinimo { get; set; }
    }

}

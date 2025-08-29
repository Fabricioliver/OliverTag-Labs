namespace InventoryControl.InventoryControl.Domain
{
    // backend/InventoryControl.Domain/Movimento.cs
    public class Movimento
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; } = null!;
        public string Tipo { get; set; } = null!; // ENTRADA/SAIDA
        public decimal Qtd { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    }

}

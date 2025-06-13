namespace GestaoFinanceira.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public DateTime DataCompra { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal ValorTotal { get; set; }
        public MetodoPagamento MetodoPagamento { get; set; } // 1 - Dinheiro, 2 - Pix, 3 - Débito, 4 - Crédito
        public int QuantidadeParcelas { get; set; } = 1;
        public int? CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public int? CartaoId { get; set; }
        public Cartao? Cartao { get; set; }
    }
}
namespace GestaoFinanceira.Models
{
    public class Parcela
    {
        public int Id { get; set; }
        public int DespesaId { get; set; }
        public Despesa Despesa { get; set; } = null!;
        public int NumeroDaParcela { get; set; } // 1, 2, 3...
        public decimal ValorParcela { get; set; }
        public DateTime DataVencimento { get; set; }
        public StatusParcela Status { get; set; } // Pendente, Pago, Cancelado, Removido...
    }
}
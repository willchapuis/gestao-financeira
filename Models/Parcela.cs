namespace GestaoFinanceira.Models
{
    public class Parcela
    {
        public int Id { get; set; }

        public int DespesaId { get; set; }
        public Despesa Despesa { get; set; }

        public int NumeroDaParcela { get; set; } // 1, 2, 3...
        public decimal ValorParcela { get; set; }
        public DateTime DataPagamento { get; set; }

        public string? Status { get; set; } // Pago, Pendente...
    }
}
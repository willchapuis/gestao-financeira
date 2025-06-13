namespace GestaoFinanceira.Models
{
    public class Receita
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal ValorLiquido { get; set; }
        public string Fonte { get; set; } = string.Empty; // Salário, Renda Extra
    }
}
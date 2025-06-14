namespace GestaoFinanceira.Models
{
    public class Cartao
    {
        public int Id { get; set; }
        public string Titular { get; set; } = string.Empty;
        public string Banco { get; set; } = string.Empty;
        public int DiaFechamento { get; set; }
    }
}
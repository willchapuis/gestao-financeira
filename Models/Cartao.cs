namespace GestaoFinanceira.Models
{
    public class Cartao
    {
        public int Id { get; set; }
        public string Titular { get; set; }
        public string Banco { get; set; }
        public int DiaFechamento { get; set; }
    }
}
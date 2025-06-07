using GestaoFinanceira.Models;

namespace GestaoFinanceira.Services
{
    public static class ParcelaGenerator
    {
        public static List<Parcela> GerarParcelas(Despesa despesa, Cartao cartao)
        {
            var parcelas = new List<Parcela>();

            int qtd = despesa.QuantidadeParcelas.Value;
            
            // Converter para centavos para evitar erros de ponto flutuante
            int totalEmCentavos = (int)Math.Round(despesa.Valor * 100);
            int valorParcelaCentavos = (int)Math.Ceiling(totalEmCentavos / (double)qtd);

            decimal valorParcelaFinal = valorParcelaCentavos / 100m;

            DateTime dataBase = despesa.Data;

            for (int i = 1; i <= qtd; i++)
            {
                DateTime dataVencimento = CalcularVencimentoParcela(despesa.Data, i, cartao.DiaFechamento);

                parcelas.Add(new Parcela
                {
                    NumeroDaParcela = i,
                    ValorParcela = valorPorParcela,
                    DataPagamento = dataVencimento,
                    DespesaId = despesa.Id,
                    Status = StatusParcela.Pendente
                });
            }

            return parcelas;
        }

        private static DateTime CalcularVencimentoParcela(DateTime dataCompra, int numeroParcela, int diaFechamento)
        {
            
        }
    }
}
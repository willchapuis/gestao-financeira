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
            bool compraAntesFechamento = dataCompra.Day < diaFechamento;

            // Define o mês do primeiro vencimento
            int mesesASomar = compraAntesFechamento ? numeroParcela - 1 : numeroParcela;

            // Avança os meses a partir do mês da compra
            DateTime baseVencimento = dataCompra.AddMonths(mesesASomar);

            // Ajusta o dia de vencimento, tratando meses com menos dias (ex: fevereiro)
            int diasNoMes = DateTime.DaysInMonth(baseVencimento.Year, baseVencimento.Month);
            int dia = Math.Min(diaFechamento, diasNoMes);

            return new DateTime(baseVencimento.Year, baseVencimento.Month, dia);
        }
    }
}
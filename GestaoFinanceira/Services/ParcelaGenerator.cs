using GestaoFinanceira.Models;

namespace GestaoFinanceira.Services
{
    public static class ParcelaGenerator
    {
        public static List<Parcela> GerarParcelas(Despesa despesa, Cartao cartao)
        {
            var parcelas = new List<Parcela>();
            
            // Converter para centavos para evitar erros de ponto flutuante
            int totalEmCentavos = (int)Math.Round(despesa.ValorTotal * 100);
            int valorParcelaCentavos = (int)Math.Ceiling(totalEmCentavos / (double)despesa.QuantidadeParcelas);

            decimal valorParcelaFinal = valorParcelaCentavos / 100m;

            DateTime dataBase = despesa.DataCompra;

            for (int i = 1; i <= despesa.QuantidadeParcelas; i++)
            {
                DateTime dataVencimento = CalcularVencimentoParcela(despesa.DataCompra, i, cartao.DiaFechamento);

                parcelas.Add(new Parcela
                {
                    NumeroDaParcela = i,
                    ValorParcela = valorParcelaFinal,
                    DataVencimento = dataVencimento,
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
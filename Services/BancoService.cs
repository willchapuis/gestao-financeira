using System.IO;
using GestaoFinanceira.Services.Database;

namespace GestaoFinanceira.Services
{
    public static class BancoService
    {
        private static readonly string CaminhoBanco = Path.Combine("Data", "banco.db");

        public static void Inicializar()
        {
            if (!Directory.Exists("Data"))
                Directory.CreateDirectory("Data");

            if (!File.Exists(CaminhoBanco))
            {
                File.Create(CaminhoBanco).Close();
            }

            CategoriaDb.CriarTabela();
            CartaoDb.CriarTabela();
            ReceitaDb.CriarTabela();
            DespesaDb.CriarTabela();
            ParcelaDb.CriarTabela();
        }

        public static string ObterCaminhoBanco()
        {
            return CaminhoBanco;
        }
    }
}
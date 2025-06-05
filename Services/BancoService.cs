using System.IO;
using GestaoFinanceira.Services.Database;

namespace GestaoFinanceira.Services
{
    public static class BancoService
    {
        public static string StringConexao => "Data Source=Data/banco.db";

        public static void AtualizarDataFim(string nomeTabela, int id) // Soft Delete - Remoção Lógica
        {
            var query = $@"
                UPDATE {nomeTabela}
                SET DataFim = @DataFim
                WHERE Id = @Id AND DataFim IS NULL;
            ";

            var dataHoraAtual = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

            ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@DataFim", dataHoraAtual);
                cmd.Parameters.AddWithValue("@Id", id);
            });
        }

        public static void ConsultarComParametros(string query, Action<SQLiteDataReader> processar, params SQLiteParameter[] parametros)
        {
            using var conexao = ObterConexao();
            using var comando = new SQLiteCommand(query, conexao);

            // Adiciona parâmetros se existirem
            if (parametros != null && parametros.Length > 0)
            {
                comando.Parameters.AddRange(parametros);
            }

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                processar(reader);
            }
        }

        public static int ExecutarComando(string query, Dictionary<string, object?> parametros)
        {
            using var conexao = ObterConexaoAberta();
            using var cmd = conexao.CreateCommand();
            cmd.CommandText = query;

            foreach (var param in parametros)
            {
                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
            }

            return cmd.ExecuteNonQuery();
        }

        public static object? ExecutarEscalar(string query, Dictionary<string, object?> parametros)
        {
            using var conexao = ObterConexaoAberta();
            using var cmd = conexao.CreateCommand();
            cmd.CommandText = query;

            foreach (var param in parametros)
            {
                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
            }

            return cmd.ExecuteScalar();
        }

        public static void ExecutarScript(string script)
        {
            using var conexao = ObterConexaoAberta();
            using var cmd = conexao.CreateCommand();
            cmd.CommandText = script;
            cmd.ExecuteNonQuery();
        }

        public static void Inicializar()
        {
            var script = @"
                CREATE TABLE IF NOT EXISTS Categoria (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    DataFim TEXT
                );

                CREATE TABLE IF NOT EXISTS Cartao (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Titular TEXT NOT NULL,
                    Banco TEXT NOT NULL,
                    DiaFechamento INTEGER NOT NULL,
                    DataFim TEXT
                );

                CREATE TABLE IF NOT EXISTS Receita (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Data TEXT NOT NULL,
                    Descricao TEXT NOT NULL,
                    Valor REAL NOT NULL,
                    DataFim TEXT
                );

                CREATE TABLE IF NOT EXISTS Despesa (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Data TEXT NOT NULL,
                    Descricao TEXT NOT NULL,
                    Valor REAL NOT NULL,
                    MetodoPagamento INTEGER NOT NULL,
                    CategoriaId INTEGER,
                    CartaoId INTEGER,
                    QuantidadeParcelas INTEGER,
                    FOREIGN KEY (CategoriaId) REFERENCES Categoria(Id),
                    FOREIGN KEY (CartaoId) REFERENCES Cartao(Id),
                    DataFim TEXT
                );

                CREATE TABLE IF NOT EXISTS Parcela (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    DespesaId INTEGER NOT NULL,
                    NumeroDaParcela INTEGER NOT NULL,
                    Valor REAL NOT NULL,
                    DataVencimento TEXT NOT NULL,
                    Status INTEGER NOT NULL,
                    FOREIGN KEY (DespesaId) REFERENCES Despesa(Id)
                );
            ";

            ExecutarScript(script);
        }

        public static SQLiteConnection ObterConexaoAberta()
        {
            var conexao = new SQLiteConnection(StringConexao);
            conexao.Open();
            return conexao;
        }
    }
}
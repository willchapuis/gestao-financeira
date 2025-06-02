using System.Data.SQLite;
using GestaoFinanceira.Services;

namespace GestaoFinanceira.Services.Database
{
    public static void CriarTabela()
    {
        using var conexao = new SQLiteConnection($"Data Source={BancoService.ObterCaminhoBanco()}");
        conexao.Open();

        var comando = conexao.CreateCommand();
        comando.CommandText = @"
            CREATE TABLE IF NOT EXISTS Categoria (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Nome TEXT NOT NULL
            );
        ";
        comando.ExecuteNonQuery();
    }

    // Métodos futuros: Inserir, Buscar, Atualizar, etc.
}
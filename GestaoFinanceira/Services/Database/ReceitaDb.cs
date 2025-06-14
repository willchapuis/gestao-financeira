using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GestaoFinanceira.Models;
using GestaoFinanceira.Services;

namespace GestaoFinanceira.Services.Database
{
    public static class ReceitaDb
    {
        public static Receita? BuscarPorId(int id)
        {
            var query = @"
                SELECT Id, Data, Descricao, ValorLiquido
                FROM Receita
                WHERE Id = @Id AND DataFim IS NULL;";

            Receita? receita = null;

            BancoService.ConsultarComParametros(query, reader =>
            {
                receita = new Receita
                {
                    Id = reader.GetInt32(0),
                    Data = reader.GetDateTime(1),
                    Descricao = reader.GetString(2),
                    ValorLiquido = (decimal)reader.GetDouble(3)
                };
            }, new SQLiteParameter("@Id", id));

            return receita;
        }

        public static void Inserir(Receita receita)
        {
            var query = @"
                INSERT INTO Receita (
                    Data, Descricao, ValorLiquido
                ) VALUES (
                    @Data, @Descricao, @ValorLiquido
                );
            ";

            var parametros = new Dictionary<string, object?>
            {
                {"@Data", receita.Data },
                {"@Descricao", receita.Descricao },
                {"@ValorLiquido", receita.ValorLiquido }
            };

            BancoService.ExecutarComando(query, parametros);
        }

        public static void Alterar(Receita receita)
        {
            var query = @"
                UPDATE Receita SET
                    Data = @Data,
                    Descricao = @Descricao,
                    ValorLiquido = @ValorLiquido
                WHERE Id = @Id AND DataFim IS NULL;
            ";

            var parametros = new Dictionary<string, object?>
            {
                {"@Data", receita.Data },
                {"@Descricao", receita.Descricao },
                {"@ValorLiquido", receita.ValorLiquido },
                {"@Id", receita.Id }
            };

            BancoService.ExecutarComando(query, parametros);
        }

        public static List<Receita> Listar()
        {
            var query = @"
                SELECT Id, Data, Descricao, ValorLiquido
                FROM Receita
                WHERE DataFim IS NULL
                ORDER BY Data
            ";

            var receitas = new List<Receita>();

            BancoService.ConsultarComParametros(query, reader =>
            {
                var receita = new Receita
                {
                    Id = reader.GetInt32(0),
                    Data = reader.GetDateTime(1),
                    Descricao = reader.GetString(2),
                    ValorLiquido = (decimal)reader.GetDouble(3)
                };

                receitas.Add(receita);
            });

            return receitas;
        }

        public static void Remover(int id)
        {
            var query = @"UPDATE Receita SET DataFim = @DataFim WHERE Id = @Id;";

            var dataHoraAtual = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

            var parametros = new Dictionary<string, object?>
            {
                {"@DataFim", dataHoraAtual },
                {"@Id", id }
            };

            BancoService.ExecutarComando(query, parametros);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GestaoFinanceira.Models;
using GestaoFinanceira.Services;

namespace GestaoFinanceira.Services.Database
{
    public static class ReceitaDb
    {
        public static void Inserir(Receita receita)
        {
            var query = @"
                INSERT INTO Receita (
                    Data, Descricao, Valor
                ) VALUES (
                    @Data, @Descricao, @Valor
                );
            ";

            BancoService.ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Data", receita.Data);
                cmd.Parameters.AddWithValue("@Descricao", receita.Descricao);
                cmd.Parameters.AddWithValue("@Valor", receita.Valor);
            });
        }

        public static void Alterar(Receita receita)
        {
            var query = @"
                UPDATE Receita SET
                    Data = @Data,
                    Descricao = @Descricao,
                    Valor = @Valor
                WHERE Id = @Id AND DataFim IS NULL;
            ";

            BancoService.ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Data", receita.Data.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Descricao", receita.Descricao);
                cmd.Parameters.AddWithValue("@Valor", receita.Valor);
                cmd.Parameters.AddWithValue("@Id", receita.Id);
            });
        }

        public static void Remover(int id)
        {
            var comando = @"UPDATE Receita SET DataFim = @DataFim WHERE Id = @Id;";

            var dataHoraAtual = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

            BancoService.ExecutarComando(comando, cmd =>
            {
                cmd.Parameters.AddWithValue("@DataFim", dataHoraAtual);
                cmd.Parameters.AddWithValue("@Id", id);
            });
        }
    }
}
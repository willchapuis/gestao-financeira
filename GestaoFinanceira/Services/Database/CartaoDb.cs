using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GestaoFinanceira.Models;
using GestaoFinanceira.Services;

namespace GestaoFinanceira.Services.Database
{
    public static class CartaoDb
    {
        public static Cartao? BuscarPorId(int id)
        {
            var query = @"
                SELECT Id, Titular, Banco, DiaFechamento
                FROM Cartao
                WHERE Id = @Id AND DataFim IS NULL;";

            Cartao? cartao = null;

            BancoService.ConsultarComParametros(query, reader =>
            {
                cartao = new Cartao
                {
                    Id = reader.GetInt32(0),
                    Titular = reader.GetString(1),
                    Banco = reader.GetString(2),
                    DiaFechamento = reader.GetInt32(3)
                };
            }, new SQLiteParameter("@Id", id));

            return cartao;
        }

        public static void Inserir(Cartao cartao)
        {
            var query = @"
                INSERT INTO Cartao (
                    Titular, Banco, DiaFechamento
                ) VALUES (
                    @Titular, @Banco, @DiaFechamento
                );
            ";

            var parametros = new Dictionary<string, object?>
            {
                {"@Titular", cartao.Titular },
                {"@Banco", cartao.Banco },
                {"@DiaFechamento", cartao.DiaFechamento }
            };

            BancoService.ExecutarComando(query, parametros);
        }

        public static void Alterar(Cartao cartao)
        {
            var query = @"
                UPDATE Cartao SET
                    Titular = @Titular,
                    Banco = @Banco,
                    DiaFechamento = @DiaFechamento
                WHERE Id = @Id AND DataFim IS NULL;
            ";

            var parametros = new Dictionary<string, object?>
            {
                {"@Titular", cartao.Titular },
                {"@Banco", cartao.Banco },
                {"@DiaFechamento", cartao.DiaFechamento },
                {"@Id", cartao.Id }
            };

            BancoService.ExecutarComando(query, parametros);
        }

        public static List<Cartao> Listar()
        {
            var query = @"
                SELECT Id, Titular, Banco, DiaFechamento
                FROM Cartao
                WHERE DataFim IS NULL
                ORDER BY Titular, DiaFechamento
            ";

            var cartaos = new List<Cartao>();

            BancoService.ConsultarComParametros(query, reader =>
            {
                var cartao = new Cartao
                {
                    Id = reader.GetInt32(0),
                    Titular = reader.GetString(1),
                    Banco = reader.GetString(2),
                    DiaFechamento = reader.GetInt32(3)
                };

                cartaos.Add(cartao);
            });

            return cartaos;
        }

        public static void Remover(int id) // Soft Delete - Remoção Lógica
        {
            BancoService.AtualizarDataFim("Cartao", id);
        }
    }
}
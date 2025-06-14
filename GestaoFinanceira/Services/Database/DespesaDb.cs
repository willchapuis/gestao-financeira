using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GestaoFinanceira.Models;
using GestaoFinanceira.Services;

namespace GestaoFinanceira.Services.Database
{
    public static class DespesaDb
    {
        public static Despesa? BuscarPorId(int id)
        {
            var query = @"
                SELECT Id, DataCompra, Descricao, ValorTotal, 
                MetodoPagamento, QuantidadeParcelas, CategoriaId, CartaoId
                FROM Despesa
                WHERE Id = @Id AND DataFim IS NULL;";

            Despesa? despesa = null;

            BancoService.ConsultarComParametros(query, reader =>
            {
                despesa = new Despesa
                {
                    Id = reader.GetInt32(0),
                    DataCompra = reader.GetDateTime(1),
                    Descricao = reader.GetString(2),
                    ValorTotal = (decimal)reader.GetDouble(3),
                    MetodoPagamento = (MetodoPagamento)reader.GetInt32(4),
                    QuantidadeParcelas = reader.GetInt32(5),
                    CategoriaId = reader.GetInt32(6),
                    CartaoId = reader.GetInt32(7)
                };
            }, new SQLiteParameter("@Id", id));

            return despesa;
        }

        public static void Alterar(Despesa despesa)
        {
            var query = @"
                UPDATE Despesa SET
                    DataCompra = @DataCompra,
                    Descricao = @Descricao,
                    ValorTotal = @ValorTotal,
                    MetodoPagamento = @MetodoPagamento,
                    QuantidadeParcelas = @QuantidadeParcelas,
                    CategoriaId = @CategoriaId,
                    CartaoId = @CartaoId
                WHERE Id = @Id AND DataFim IS NULL;
            ";

            var parametros = new Dictionary<string, object?>
            {
                {"@DataCompra", despesa.DataCompra.ToString("yyyy-MM-dd") },
                {"@Descricao", despesa.Descricao },
                {"@ValorTotal", despesa.ValorTotal },
                {"@MetodoPagamento", (int)despesa.MetodoPagamento },
                {"@QuantidadeParcelas", despesa.QuantidadeParcelas },
                {"@CategoriaId", despesa.CategoriaId.HasValue ? despesa.CategoriaId : DBNull.Value },
                {"@CartaoId", despesa.CartaoId.HasValue ? despesa.CartaoId : DBNull.Value },
                {"@Id", despesa.Id }
            };

            BancoService.ExecutarComando(query, parametros);
        }

        public static void Inserir(Despesa despesa)
        {
            var query = @"
                INSERT INTO Despesa (
                    DataCompra, Descricao, ValorTotal, MetodoPagamento, 
                    QuantidadeParcelas, CategoriaId, CartaoId
                ) VALUES (
                    @DataCompra, @Descricao, @ValorTotal, @MetodoPagamento,
                    @QuantidadeParcelas, @CategoriaId, @CartaoId
                );
                SELECT last_insert_rowid();
            ";

            var parametros = new Dictionary<string, object?>
            {
                {"@DataCompra", despesa.DataCompra.ToString("yyyy-MM-dd") },
                {"@Descricao", despesa.Descricao },
                {"@ValorTotal", despesa.ValorTotal },
                {"@MetodoPagamento", (int)despesa.MetodoPagamento },
                {"@QuantidadeParcelas", despesa.QuantidadeParcelas },
                {"@CategoriaId", despesa.CategoriaId.HasValue ? despesa.CategoriaId : DBNull.Value },
                {"@CartaoId", despesa.CartaoId.HasValue ? despesa.CartaoId : DBNull.Value }
            };

            object? idObj = BancoService.ExecutarEscalar(query, parametros);

            // Se for Cartão de Crédito, gerar e inserir parcelas
            if (despesa.MetodoPagamento == MetodoPagamento.Credito && despesa.CartaoId.HasValue && despesa.QuantidadeParcelas > 1)
            {
                var cartao = CartaoDb.BuscarPorId(despesa.CartaoId.Value);

                if (cartao == null)
                    throw new Exception("Cartão de crédito não encontrado.");

                var parcelas = ParcelaGenerator.GerarParcelas(despesa, cartao);

                foreach (var parcela in parcelas)
                {
                    ParcelaDb.Inserir(parcela);
                }
            }
        }

        public static List<Despesa> Listar()
        {
            var query = @"
                SELECT Id, DataCompra, Descricao, ValorTotal, MetodoPagamento,
                    QuantidadeParcelas, CategoriaId, CartaoId
                FROM Despesa
                WHERE DataFim IS NULL
                ORDER BY DataCompra
            ";

            var despesas = new List<Despesa>();

            BancoService.ConsultarComParametros(query, reader =>
            {
                var despesa = new Despesa
                {
                    Id = reader.GetInt32(0),
                    DataCompra = DateTime.Parse(reader.GetString(1)),
                    Descricao = reader.GetString(2),
                    ValorTotal = reader.GetDecimal(3),
                    MetodoPagamento = (MetodoPagamento)reader.GetInt32(4),
                    QuantidadeParcelas = reader.GetInt32(5),
                    CategoriaId = reader.IsDBNull(6) ? null : reader.GetInt32(6),
                    CartaoId = reader.IsDBNull(7) ? null : reader.GetInt32(7)
                };

                despesas.Add(despesa);
            });

            return despesas;
        }

        public static void Remover(int id) // Soft Delete - Remoção Lógica
        {
            BancoService.AtualizarDataFim("Despesa", id);

            ParcelaDb.RemoverPendentesPorDespesa(id);
        }
    }
}
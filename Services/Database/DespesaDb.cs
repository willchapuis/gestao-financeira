using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GestaoFinanceira.Models;
using GestaoFinanceira.Services;

namespace GestaoFinanceira.Services.Database
{
    public static class DespesaDb
    {
        public static void Alterar(Despesa despesa)
        {
            var query = @"
                UPDATE Despesa SET
                    Data = @Data,
                    Descricao = @Descricao,
                    Valor = @Valor,
                    MetodoPagamento = @MetodoPagamento,
                    QuantidadeParcelas = @QuantidadeParcelas,
                    CategoriaId = @CategoriaId,
                    CartaoId = @CartaoId
                WHERE Id = @Id AND DataFim IS NULL;
            ";

            BancoService.ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Data", despesa.Data.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Descricao", despesa.Descricao);
                cmd.Parameters.AddWithValue("@Valor", despesa.Valor);
                cmd.Parameters.AddWithValue("@MetodoPagamento", (int)despesa.MetodoPagamento);
                cmd.Parameters.AddWithValue("@QuantidadeParcelas", despesa.QuantidadeParcelas.HasValue ? despesa.QuantidadeParcelas : DBNull.Value);
                cmd.Parameters.AddWithValue("@CategoriaId", despesa.CategoriaId.HasValue ? despesa.CategoriaId : DBNull.Value);
                cmd.Parameters.AddWithValue("@CartaoId", despesa.CartaoId.HasValue ? despesa.CartaoId : DBNull.Value);
                cmd.Parameters.AddWithValue("@Id", despesa.Id);
            });
        }

        public static void Inserir(Despesa despesa)
        {
            var query = @"
                INSERT INTO Despesa (
                    Data, Descricao, Valor, MetodoPagamento,
                    CategoriaId, CartaoId, QuantidadeParcelas
                ) VALUES (
                    @Data, @Descricao, @Valor, @MetodoPagamento,
                    @CategoriaId, @CartaoId, @QuantidadeParcelas
                );
            ";

            BancoService.ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Data", despesa.Data.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Descricao", despesa.Descricao);
                cmd.Parameters.AddWithValue("@Valor", despesa.Valor);
                cmd.Parameters.AddWithValue("@MetodoPagamento", (int)despesa.MetodoPagamento);
                cmd.Parameters.AddWithValue("@CategoriaId", despesa.CategoriaId.HasValue ? despesa.CategoriaId : DBNull.Value);
                cmd.Parameters.AddWithValue("@CartaoId", despesa.CartaoId.HasValue ? despesa.CartaoId : DBNull.Value);
                cmd.Parameters.AddWithValue("@QuantidadeParcelas", despesa.QuantidadeParcelas.HasValue ? despesa.QuantidadeParcelas : DBNull.Value);
            });
        }

        public static List<Despesa> Listar()
        {
            var query = @"
                SELECT Id, Data, Descricao, Valor, MetodoPagamento,
                    QuantidadeParcelas, CategoriaId, CartaoId
                FROM Despesa
                WHERE DataFim IS NULL;
            ";

            var despesas = new List<Despesa>();

            BancoService.ConsultarComParametros(query, reader =>
            {
                var despesa = new Despesa
                {
                    Id = reader.GetInt32(0),
                    Data = DateTime.Parse(reader.GetString(1)),
                    Descricao = reader.GetString(2),
                    Valor = reader.GetDecimal(3),
                    MetodoPagamento = (MetodoPagamento)reader.GetInt32(4),
                    QuantidadeParcelas = reader.IsDBNull(5) ? null : reader.GetInt32(5),
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

            ParcelaDb.RemoverPendentesPorDespesa(despesa.Id);
        }
    }
}
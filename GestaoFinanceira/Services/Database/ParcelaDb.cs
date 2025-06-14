using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GestaoFinanceira.Models;
using GestaoFinanceira.Services;

namespace GestaoFinanceira.Services.Database
{
    public static class ParcelaDb
    {
        public static Parcela? BuscarPorId(int id)
        {
            var query = @"
                SELECT Id, Data, Descricao, ValorLiquido
                FROM Parcela
                WHERE Id = @Id AND DataFim IS NULL;";

            Parcela? parcela = null;

            BancoService.ConsultarComParametros(query, reader =>
            {
                parcela = new Parcela
                {
                    Id = reader.GetInt32(0),
                    DespesaId = reader.GetInt32(1),
                    NumeroDaParcela = reader.GetInt32(2),
                    ValorParcela = (decimal)reader.GetDouble(3),
                    DataVencimento = reader.GetDateTime(4),
                    Status = (StatusParcela)reader.GetInt32(5)
                };
            }, new SQLiteParameter("@Id", id));

            return parcela;
        }

        public static void Inserir(Parcela parcela)
        {
            var query = @"
                INSERT INTO Parcela (
                    DespesaId, NumeroDaParcela, ValorParcela, 
                    DataVencimento, Status
                ) VALUES (
                    @DespesaId, @NumeroDaParcela, @ValorParcela, 
                    @DataVencimento, @Status
                );
            ";

            var parametros = new Dictionary<string, object?>
            {
                {"@DespesaId", parcela.DespesaId },
                {"@NumeroDaParcela", parcela.NumeroDaParcela },
                {"@ValorParcela", parcela.ValorParcela },
                {"@DataVencimento", parcela.DataVencimento.ToString("yyyy-MM-dd") },
                {"@Status", (int)parcela.Status }
            };

            BancoService.ExecutarComando(query, parametros);
        }

        public static void Alterar(Parcela parcela)
        {
            var query = @"
                UPDATE Parcela SET
                    DespesaId = @DespesaId,
                    NumeroDaParcela = @NumeroDaParcela,
                    ValorParcela = @ValorParcela,
                    DataVencimento = @DataVencimento,
                    Status = @Status
                WHERE Id = @Id;
            ";

            var parametros = new Dictionary<string, object?>
            {
                {"@DespesaId", parcela.DespesaId },
                {"@NumeroDaParcela", parcela.NumeroDaParcela },
                {"@ValorParcela", parcela.ValorParcela },
                {"@DataVencimento", parcela.DataVencimento.ToString("yyyy-MM-dd") },
                {"@Status", (int)parcela.Status },
                {"@Id", parcela.Id }
            };

            BancoService.ExecutarComando(query, parametros);
        }

        public static List<Parcela> Listar(Dictionary<string, object?>? filtros)
        {
            var parcelas = new List<Parcela>();

            var query = @"
                SELECT Id, DespesaId, NumeroDaParcela, ValorParcela, DataVencimento, Status
                FROM Parcela
                WHERE 1=1
            ";

            var parametros = new List<SQLiteParameter>();

            if(filtros != null)
            {
                foreach (var filtro in filtros) // Filtros dinâmicos
                {
                    if (filtro.Value == null)
                    {
                        query += $" AND {filtro.Key} IS NULL";
                    }
                    else if (filtro.Value == DBNull.Value)
                    {
                        query += $" AND {filtro.Key} IS NOT NULL";
                    }
                    else
                    {
                        query += $" AND {filtro.Key} = @{filtro.Key}";
                        parametros.Add(new SQLiteParameter(filtro.Key, filtro.Value));
                    }
                }
            }

            query += " ORDER BY DataVencimento";

            BancoService.ConsultarComParametros(query, reader =>
            {
                var parcela = new Parcela
                {
                    Id = reader.GetInt32(0),
                    DespesaId = reader.GetInt32(1),
                    NumeroDaParcela = reader.GetInt32(2),
                    ValorParcela = (decimal)reader.GetDouble(3),
                    DataVencimento = reader.GetDateTime(4),
                    Status = (StatusParcela)reader.GetInt32(5)
                };

                parcelas.Add(parcela);
            }, parametros.ToArray());

            return parcelas;
        }

        public static void RemoverPendentesPorDespesa(int despesaId)
        {
            var query = @"
                UPDATE Parcela SET Status = @NovoStatus
                WHERE DespesaId = @DespesaId AND Status = @StatusPendente;
            ";

            var parametros = new Dictionary<string, object?>
            {
                {"@NovoStatus", (int)StatusParcela.Removido },
                {"@DespesaId", despesaId },
                {"@StatusPendente", (int)StatusParcela.Pendente }
            };

            BancoService.ExecutarComando(query, parametros);
        }
    }
}
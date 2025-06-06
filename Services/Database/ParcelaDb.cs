using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GestaoFinanceira.Models;
using GestaoFinanceira.Services;

namespace GestaoFinanceira.Services.Database
{
    public static class ParcelaDb
    {
        public static void Inserir(Parcela parcela)
        {
            var query = @"
                INSERT INTO Parcela (
                    DespesaId, NumeroDaParcela, Valor, 
                    DataVencimento, Status
                ) VALUES (
                    @DespesaId, @NumeroDaParcela, @Valor, 
                    @DataVencimento, @Status
                );
            ";

            BancoService.ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@DespesaId", parcela.DespesaId.HasValue ? parcela.DespesaId : DBNull.Value);
                cmd.Parameters.AddWithValue("@NumeroDaParcela", parcela.NumeroDaParcela);
                cmd.Parameters.AddWithValue("@Valor", parcela.Valor);
                cmd.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Status", parcela.Status);
            });
        }

        public static void Alterar(Parcela parcela)
        {
            var query = @"
                UPDATE Parcela SET
                    DespesaId = @DespesaId,
                    NumeroDaParcela = @NumeroDaParcela,
                    Valor = @Valor,
                    DataVencimento = @DataVencimento,
                    Status = @Status
                WHERE Id = @Id;
            ";

            BancoService.ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@DespesaId", parcela.DespesaId);
                cmd.Parameters.AddWithValue("@NumeroDaParcela", parcela.NumeroDaParcela);
                cmd.Parameters.AddWithValue("@Valor", parcela.Valor);
                cmd.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Status", (int)parcela.Status);
                cmd.Parameters.AddWithValue("@Id", despesa.Id);
            });
        }

        public static List<Parcela> Listar(Dictionary<string, object>? filtros = null)
        {
            var parcelas = new List<Parcela>();

            var query = @"
                SELECT 
                    Parcela.Id, 
                    Parcela.DespesaId, 
                    Parcela.NumeroDaParcela, 
                    Parcela.Valor, 
                    Parcela.DataVencimento, 
                    Parcela.Status
                FROM Parcela
                JOIN Despesa ON Despesa.Id = Parcela.DespesaId
            ";

            if (filtros != null && filtros.Count > 0)
            {
                var condicoes = new List<string>();
                foreach (var filtro in filtros.Keys)
                {
                    string parametroNome = filtro.Replace(".", "_");
                    condicoes.Add($"{filtro} = @{parametroNome}");
                }

                query += " WHERE " + string.Join(" AND ", condicoes);
            }

            BancoService.ExecutarConsulta(query, filtros, reader =>
            {
                parcelas.Add(new Parcela
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    DespesaId = Convert.ToInt32(reader["DespesaId"]),
                    NumeroDaParcela = Convert.ToInt32(reader["NumeroDaParcela"]),
                    ValorParcela = Convert.ToDecimal(reader["Valor"]),
                    DataPagamento = DateTime.Parse(reader["DataVencimento"].ToString()!),
                    Status = (StatusParcela)Convert.ToInt32(reader["Status"])
                });
            });

            return parcelas;
        }

        public static void RemoverPendentesPorDespesa(int despesaId)
        {
            var query = @"
                UPDATE Parcela SET Status = @NovoStatus
                WHERE DespesaId = @DespesaId AND Status = @StatusPendente;
            ";

            BancoService.ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@NovoStatus", (int)StatusParcela.Removido);
                cmd.Parameters.AddWithValue("@DespesaId", despesaId);
                cmd.Parameters.AddWithValue("@StatusPendente", (int)StatusParcela.Pendente);
            });
        }
    }
}
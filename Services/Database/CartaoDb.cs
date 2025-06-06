using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GestaoFinanceira.Models;
using GestaoFinanceira.Services;

namespace GestaoFinanceira.Services.Database
{
    public static class CartaoDb
    {
        public static void Inserir(Cartao cartao)
        {
            var query = @"
                INSERT INTO Cartao (
                    Titular, Banco, DiaFechamento
                ) VALUES (
                    @Titular, @Banco, @DiaFechamento
                );
            ";

            BancoService.ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Titular", cartao.Titular);
                cmd.Parameters.AddWithValue("@Banco", cartao.Banco);
                cmd.Parameters.AddWithValue("@DiaFechamento", cartao.DiaFechamento);
            });
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

            BancoService.ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Titular", cartao.Titular);
                cmd.Parameters.AddWithValue("@Banco", cartao.Banco);
                cmd.Parameters.AddWithValue("@DiaFechamento", cartao.DiaFechamento);
                cmd.Parameters.AddWithValue("@Id", despesa.Id);
            });
        }

        public static List<Cartao> Listar()
        {
            var query = @"
                SELECT Id, Titular, Banco, DiaFechamento
                FROM Cartao
                WHERE DataFim IS NULL;
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
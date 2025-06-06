using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GestaoFinanceira.Models;
using GestaoFinanceira.Services;

namespace GestaoFinanceira.Services.Database
{
    public static class CategoriaDb
    {
        public static void Inserir(Categoria categoria)
        {
            var query = @"INSERT INTO Categoria (Nome) VALUES (@Nome);";

            BancoService.ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Nome", categoria.Nome);
            });
        }

        public static void Alterar(Categoria categoria)
        {
            var query = @"
                UPDATE Categoria SET Nome = @Nome
                WHERE Id = @Id AND DataFim IS NULL;
            ";

            BancoService.ExecutarComando(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Nome", categoria.Nome);
                cmd.Parameters.AddWithValue("@Id", categoria.Id);
            });
        }

        public static List<Despesa> Listar()
        {
            var query = @"
                SELECT Id, Nome
                FROM Categoria
                WHERE DataFim IS NULL;
            ";

            var categorias = new List<Categoria>();

            BancoService.ConsultarComParametros(query, reader =>
            {
                var categoria = new Categoria
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                };

                categorias.Add(categoria);
            });

            return categorias;
        }

        public static void Remover(int id) // Soft Delete - Remoção Lógica
        {
            BancoService.AtualizarDataFim("Categoria", id);
        }
    }
}
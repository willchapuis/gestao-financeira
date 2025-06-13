using System;
using System.Collections.Generic;
using System.Data.SQLite;
using GestaoFinanceira.Models;
using GestaoFinanceira.Services;

namespace GestaoFinanceira.Services.Database
{
    public static class CategoriaDb
    {
        public static Categoria? BuscarPorId(int id)
        {
            var query = @"
                SELECT Id, Nome, DataFim
                FROM Categoria
                WHERE Id = @Id AND DataFim IS NULL;";

            Categoria? categoria = null;

            BancoService.ConsultarComParametros(query, reader =>
            {
                categoria = new Categoria
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                };
            }, new SQLiteParameter("@Id", id));

            return categoria;
        }

        public static void Inserir(Categoria categoria)
        {
            var query = @"INSERT INTO Categoria (Nome) VALUES (@Nome);";

            var parametros = new Dictionary<string, object?>
            {
                {"@Nome", categoria.Nome }
            };

            BancoService.ExecutarComando(query, parametros);
        }

        public static void Alterar(Categoria categoria)
        {
            var query = @"
                UPDATE Categoria SET Nome = @Nome
                WHERE Id = @Id AND DataFim IS NULL;
            ";

            var parametros = new Dictionary<string, object?>
            {
                {"@Nome", categoria.Nome },
                {"@Id", categoria.Id }
            };

            BancoService.ExecutarComando(query, parametros);
        }

        public static List<Categoria> Listar()
        {
            var query = @"
                SELECT Id, Nome
                FROM Categoria
                WHERE DataFim IS NULL
                ORDER BY Nome
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
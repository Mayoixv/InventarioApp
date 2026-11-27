using InventarioApp.Data;
using InventarioApp.Models;
using Microsoft.Data.SqlClient;

namespace InventarioApp.Features;

public static class Listar
{
    public static void MapListar(this WebApplication app)
    {
        app.MapGet("/api/productos", async (Db db) =>
        {
            await using var connection = await db.OpenAsync();
            await using var command = new SqlCommand(
                "SELECT Id, Nombre, Precio, Cantidad FROM dbo.Productos ORDER BY Id", connection);
            await using var reader = await command.ExecuteReaderAsync();

            var productos = new List<Producto>();
            while (await reader.ReadAsync())
                productos.Add(new Producto(reader.GetInt32(0), reader.GetString(1),
                    reader.GetDecimal(2), reader.GetInt32(3)));

            return Results.Ok(productos);
        });
    }
}

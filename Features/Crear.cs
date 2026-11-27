using InventarioApp.Data;
using InventarioApp.Models;
using Microsoft.Data.SqlClient;

namespace InventarioApp.Features;

public static class Crear
{
    public static void MapCrear(this WebApplication app)
    {
        app.MapPost("/api/productos", async (Producto p, Db db) =>
        {
            await using var connection = await db.OpenAsync();
            await using var command = new SqlCommand(
                @"INSERT INTO dbo.Productos (Nombre, Precio, Cantidad)
                  OUTPUT INSERTED.Id VALUES (@nombre, @precio, @cantidad)", connection);
            command.Parameters.AddWithValue("@nombre", p.Nombre);
            command.Parameters.AddWithValue("@precio", p.Precio);
            command.Parameters.AddWithValue("@cantidad", p.Cantidad);

            var id = (int)(await command.ExecuteScalarAsync())!;
            return Results.Created($"/api/productos/{id}", p with { Id = id });
        });
    }
}

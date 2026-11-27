using InventarioApp.Data;
using InventarioApp.Models;
using Microsoft.Data.SqlClient;

namespace InventarioApp.Features;

public static class Editar
{
    public static void MapEditar(this WebApplication app)
    {
        app.MapPut("/api/productos/{id:int}", async (int id, Producto p, Db db) =>
        {
            await using var connection = await db.OpenAsync();
            await using var command = new SqlCommand(
                @"UPDATE dbo.Productos
                  SET Nombre = @nombre, Precio = @precio, Cantidad = @cantidad
                  WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@nombre", p.Nombre);
            command.Parameters.AddWithValue("@precio", p.Precio);
            command.Parameters.AddWithValue("@cantidad", p.Cantidad);

            return await command.ExecuteNonQueryAsync() == 0 ? Results.NotFound() : Results.NoContent();
        });
    }
}

using InventarioApp.Data;
using Microsoft.Data.SqlClient;

namespace InventarioApp.Features;

public static class Eliminar
{
    public static void MapEliminar(this WebApplication app)
    {
        app.MapDelete("/api/productos/{id:int}", async (int id, Db db) =>
        {
            await using var connection = await db.OpenAsync();
            await using var command = new SqlCommand(
                "DELETE FROM dbo.Productos WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);

            return await command.ExecuteNonQueryAsync() == 0 ? Results.NotFound() : Results.NoContent();
        });
    }
}

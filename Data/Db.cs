using Microsoft.Data.SqlClient;

namespace InventarioApp.Data;

public class Db(string connectionString)
{
    public async Task<SqlConnection> OpenAsync()
    {
        var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        return connection;
    }
}

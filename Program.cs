using InventarioApp.Data;
using InventarioApp.Features;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Inventario")!;
builder.Services.AddSingleton(new Db(connectionString));

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapListar();

app.Run();

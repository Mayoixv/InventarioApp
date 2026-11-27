# InventarioApp

CRUD de productos con ASP.NET Core (.NET 10), SQL Server y una pagina web en HTML y JavaScript.

## Requisitos
- SDK de .NET 10
- SQL Server (Express sirve)

## Ejecucion
1. Ejecutar `database/schema.sql` en SQL Server.
2. Ajustar la cadena de conexion en `appsettings.json`.
3. Ejecutar `dotnet run` y abrir la URL que muestra la consola.

## Flujo de ramas
`main`, `develop`, `qa` y ramas `feature/*`. Cada feature se integra mediante un Pull Request a `develop`, otro a `qa` y otro a `main`.

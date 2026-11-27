using InventarioApp.Models;

namespace InventarioApp.Validation;

public static class ProductoValidator
{
    public static string? Validar(Producto p)
    {
        if (string.IsNullOrWhiteSpace(p.Nombre)) return "El nombre es obligatorio.";
        if (p.Nombre.Length > 100) return "El nombre no puede pasar de 100 caracteres.";
        if (p.Precio <= 0 || p.Precio > 99999999.99m) return "El precio debe ser mayor que 0 y menor que 100 millones.";
        if (p.Cantidad < 0) return "La cantidad no puede ser negativa.";
        return null;
    }
}

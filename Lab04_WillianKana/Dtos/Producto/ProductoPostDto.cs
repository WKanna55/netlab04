namespace Lab04_WillianKana.Dtos.Producto;

public class ProductoPostDto
{
    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public int? Categoriaid { get; set; }
}
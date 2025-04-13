namespace Lab04_WillianKana.Dtos.Producto;

public class ProductoGetDto
{
    public int Productoid { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public int? Categoriaid { get; set; }
}
using Lab04_WillianKana.Dtos.Producto;

namespace Lab04_WillianKana.Dtos.Categoria;

public class CategoriaGetDto
{
    public int Categoriaid { get; set; }

    public string Nombre { get; set; } = null!;
    
    public virtual ICollection<ProductoGetDto> Productos { get; set; } = new List<ProductoGetDto>();
}
using Lab04_WillianKana.Dtos.Producto;
using Lab04_WillianKana.Entities; //investigar este uso en la arquit. de capas N

namespace Lab04_WillianKana.Interfaces.Services;

public interface IProductoService 
    : IServiceBase<Producto, ProductoGetDto, ProductoPostDto, ProductoPutDto>
{
    
}
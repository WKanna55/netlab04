using Lab04_WillianKana.Application.Dtos.Producto;
using Lab04_WillianKana.Domain.Entities; //investigar este uso en la arquit. de capas N

namespace Lab04_WillianKana.Application.Services;

public interface IProductoService 
    : IServiceBase<Producto, ProductoGetDto, ProductoPostDto, ProductoPutDto>
{
    
}
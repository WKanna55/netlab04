using Lab04_WillianKana.Dtos.Producto;
using Lab04_WillianKana.Entities;
using Lab04_WillianKana.Interfaces.Repositories;
using Lab04_WillianKana.Interfaces.Services;

namespace Lab04_WillianKana.Services;

public class ProductoService 
    : ServiceBase<Producto, ProductoGetDto, ProductoPostDto, ProductoPutDto>, IProductoService
{
    public ProductoService(IUnitOfWork unitOfWork) : base(unitOfWork) {}


    public override Producto MapToEntity(ProductoPostDto dto)
    {
        return new Producto
        {
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion,
            Precio = dto.Precio,
            Stock = dto.Stock,
            Categoriaid = dto.Categoriaid
        };
    }

    public override ProductoGetDto MapToGetDto(Producto entity)
    {
        return new ProductoGetDto
        {
            Productoid = entity.Productoid,
            Nombre = entity.Nombre,
            Descripcion = entity.Descripcion,
            Precio = entity.Precio,
            Stock = entity.Stock,
            Categoriaid = entity.Categoriaid
        };
    }

    public override void MapUpdate(Producto entity, ProductoPutDto dto)
    {
        entity.Nombre = dto.Nombre;
        entity.Descripcion = dto.Descripcion;
        entity.Precio = dto.Precio;
        entity.Stock = dto.Stock;
        entity.Categoriaid = dto.Categoriaid;
    }
}
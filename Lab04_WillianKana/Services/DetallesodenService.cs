using Lab04_WillianKana.Dtos.Detallesorden;
using Lab04_WillianKana.Entities;
using Lab04_WillianKana.Interfaces.Repositories;
using Lab04_WillianKana.Interfaces.Services;

namespace Lab04_WillianKana.Services;

public class DetallesodenService 
    : ServiceBase<Detallesorden, DetallesordenGetDto, DetallesordenPostDto, DetallesordenPutDto>, IDetallesordenService
{
    public DetallesodenService(IUnitOfWork unitOfWork) : base(unitOfWork) {}


    public override Detallesorden MapToEntity(DetallesordenPostDto dto)
    {
        return new Detallesorden
        {
            Ordenid = dto.Ordenid,
            Productoid = dto.Productoid,
            Cantidad = dto.Cantidad,
            Precio = dto.Precio
        };
    }

    public override DetallesordenGetDto MapToGetDto(Detallesorden entity)
    {
        return new DetallesordenGetDto
        {
            Detalleid = entity.Detalleid,
            Ordenid = entity.Ordenid,
            Productoid = entity.Productoid,
            Cantidad = entity.Cantidad,
            Precio = entity.Precio
        };
    }

    public override void MapUpdate(Detallesorden entity, DetallesordenPutDto dto)
    {
        entity.Ordenid = dto.Ordenid;
        entity.Productoid = dto.Productoid;
        entity.Cantidad = dto.Cantidad;
        entity.Precio = dto.Precio;
    }
}
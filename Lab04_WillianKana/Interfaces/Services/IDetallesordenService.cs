using Lab04_WillianKana.Dtos.Detallesorden;
using Lab04_WillianKana.Entities;

namespace Lab04_WillianKana.Interfaces.Services;

public interface IDetallesordenService 
    : IServiceBase<Detallesorden, DetallesordenGetDto, DetallesordenPostDto, DetallesordenPutDto>
{
    
}
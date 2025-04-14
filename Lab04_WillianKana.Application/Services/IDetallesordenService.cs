using Lab04_WillianKana.Application.Dtos.Detallesorden;
using Lab04_WillianKana.Domain.Entities;

namespace Lab04_WillianKana.Application.Services;

public interface IDetallesordenService 
    : IServiceBase<Detallesorden, DetallesordenGetDto, DetallesordenPostDto, DetallesordenPutDto>
{
    
}
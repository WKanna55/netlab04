using Lab04_WillianKana.Application.Dtos.Pago;

namespace Lab04_WillianKana.Application.Services;

public interface IPagoService
{
    Task<IEnumerable<PagoGetDto>> GetAll();
    Task<PagoGetDto> GetById(int id);
    Task<PagoGetDto> Add(PagoPostDto pagoDto);
    Task<bool> Update(int id, PagoPutDto pagoDto);
    Task<bool> Delete(int id);
}
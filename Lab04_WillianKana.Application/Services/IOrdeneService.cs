using Lab04_WillianKana.Application.Dtos.Ordene;

namespace Lab04_WillianKana.Application.Services;

public interface IOrdeneService
{
    Task<IEnumerable<OrdeneGetDto>> GetAll();
    Task<OrdeneGetDto> GetById(int id);
    Task<OrdeneGetDto> Add(OrdenePostDto ordenePostDto);
    Task<bool> Update(int id, OrdenePutDto ordenePutDto);
    Task<bool> Delete(int id);

}
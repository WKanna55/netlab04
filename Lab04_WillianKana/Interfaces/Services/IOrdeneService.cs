using Lab04_WillianKana.Dtos.Ordene;
using Lab04_WillianKana.Entities;

namespace Lab04_WillianKana.Interfaces.Services;

public interface IOrdeneService
{
    Task<IEnumerable<OrdeneGetDto>> GetAll();
    Task<OrdeneGetDto> GetById(int id);
    Task<Ordene> Add(OrdenePostDto ordenePostDto);
    Task<bool> Update(int id, OrdenePutDto ordenePutDto);
    Task<bool> Delete(int id);

}
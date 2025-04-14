using Lab04_WillianKana.Application.Dtos.Cliente;

namespace Lab04_WillianKana.Application.Services;

public interface IClienteService
{
    Task<IEnumerable<ClienteGetDto>> GetAll();
    Task<ClienteGetDto> GetById(int id);
    Task<ClienteGetDto> Add(ClientePostDto clienteDto);

    Task<bool> Update(int id, ClientePutDto clienteDto);
    
    Task<bool> Delete(int id);

    Task<bool> Patch(int id, ClientePatchDto clienteDto);

}
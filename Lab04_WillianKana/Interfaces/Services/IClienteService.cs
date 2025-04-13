using Lab04_WillianKana.Dtos;
using Lab04_WillianKana.Entities;

namespace Lab04_WillianKana.Interfaces.Services;

public interface IClienteService
{
    Task<IEnumerable<ClienteGetDto>> GetAll();
    Task<ClienteGetDto> GetById(int id);
    Task<Cliente> Add(ClientePostDto clienteDto);

    Task<bool> Update(int id, ClientePutDto clienteDto);
    
    Task<bool> Delete(int id);

    Task<bool> Patch(int id, ClientePatchDto clienteDto);

}
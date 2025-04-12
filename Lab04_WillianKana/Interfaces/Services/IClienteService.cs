using Lab04_WillianKana.Dtos;
using Lab04_WillianKana.Entities;

namespace Lab04_WillianKana.Interfaces.Services;

public interface IClienteService
{
    Task<Cliente> Add(ClientePostDto clienteDto);
    Task<IEnumerable<ClienteGetDto>> GetAll();
}
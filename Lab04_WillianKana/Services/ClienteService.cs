using Lab04_WillianKana.Dtos;
using Lab04_WillianKana.Entities;
using Lab04_WillianKana.Interfaces.Repositories;
using Lab04_WillianKana.Interfaces.Services;

namespace Lab04_WillianKana.Services;

public class ClienteService : IClienteService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClienteService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<ClienteGetDto>> GetAll()
    {
        var clientes = await _unitOfWork.Repository<Cliente>().GetAll();;
        var clientesDto = clientes.Select(c => new ClienteGetDto
        {
            Clienteid = c.Clienteid,
            Nombre = c.Nombre,
            Correo = c.Correo
        });
        return clientesDto;
    }
    
    public async Task<Cliente> Add(ClientePostDto clienteDto)
    {
        var cliente = new Cliente
        {
            Nombre = clienteDto.Nombre,
            Correo = clienteDto.Correo
        };
        await _unitOfWork.Repository<Cliente>().Add(cliente);
        await _unitOfWork.SaveChanges();
        return cliente;
    }
    
}
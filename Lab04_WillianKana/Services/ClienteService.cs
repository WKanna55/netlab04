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

    public Cliente Add(ClientePostDto clienteDto)
    {
        var cliente = new Cliente
        {
            Nombre = clienteDto.Nombre,
            Correo = clienteDto.Correo
        };
        try
        {
            _unitOfWork.Clientes.Add(cliente);
            _unitOfWork.SaveChanges();
            return cliente;
        }
        catch (Exception)
        {
            _unitOfWork.Dispose();  // dispose
            throw;
        }
    }

    public IEnumerable<ClienteGetDto> GetAll()
    {
        var clientes = _unitOfWork.Clientes.GetAll();
        var clientesDto = clientes.Select(c => new ClienteGetDto
        {
            Clienteid = c.Clienteid,
            Nombre = c.Nombre,
            Correo = c.Correo
        });
        return clientesDto;
    }
    
}
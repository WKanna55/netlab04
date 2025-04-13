using Lab04_WillianKana.Dtos;
using Lab04_WillianKana.Entities;
using Lab04_WillianKana.Interfaces.Repositories;
using Lab04_WillianKana.Interfaces.Services;
using Microsoft.AspNetCore.Http.HttpResults;

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

    public async Task<ClienteGetDto> GetById(int id)
    {
        var cliente = await _unitOfWork.Repository<Cliente>().GetById(id);
        var clienteDto = new ClienteGetDto
        {
            Clienteid = cliente.Clienteid,
            Nombre = cliente.Nombre,
            Correo = cliente.Correo
        };
        return clienteDto;
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

    public async Task<bool> Update(int id, ClientePutDto clienteDto)
    {
        var cliente = await _unitOfWork.Repository<Cliente>().GetById(id);
        if (cliente == null) return false;
        cliente.Nombre = clienteDto.Nombre;
        cliente.Correo = clienteDto.Correo;
        await _unitOfWork.Repository<Cliente>().Update(cliente);
        await _unitOfWork.SaveChanges();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var deleted = await _unitOfWork.Repository<Cliente>().Delete(id);
        if (!deleted) return false;
        await _unitOfWork.SaveChanges();
        return true;
    }

    public async Task<bool> Patch(int id, ClientePatchDto clienteDto)
    {
        var cliente = await _unitOfWork.Repository<Cliente>().GetById(id);
        if (cliente == null) return false;
        cliente.Correo = clienteDto.Correo;
        await _unitOfWork.Repository<Cliente>().Update(cliente);
        await _unitOfWork.SaveChanges();
        return true;
    }
    
}
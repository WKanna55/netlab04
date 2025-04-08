using Lab04_WillianKana.Data;
using Lab04_WillianKana.Entities;
using Lab04_WillianKana.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_WillianKana.Controllers;

[Controller]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ClienteController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public IActionResult CrearCliente(Cliente cliente)
    {
        _unitOfWork.Clientes.Add(cliente);
        _unitOfWork.SaveChanges();
        return Ok("Cliente creado con exito");
    }

    [HttpGet]
    public IActionResult ObtenerClientes()
    {
        var clientes = _unitOfWork.Clientes.GetAll();
        return Ok(clientes);
    }
    
}
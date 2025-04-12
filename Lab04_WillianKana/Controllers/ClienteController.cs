using Lab04_WillianKana.Dtos;
using Lab04_WillianKana.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_WillianKana.Controllers;

[Controller]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpPost]
    public IActionResult Post([FromBody]ClientePostDto clienteDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var cliente = _clienteService.Add(clienteDto);

        return Ok(cliente);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var clientes = _clienteService.GetAll();
        return Ok(clientes);
    }
    
}
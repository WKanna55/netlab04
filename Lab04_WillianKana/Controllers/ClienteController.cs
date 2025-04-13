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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clientes = await _clienteService.GetAll();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute]int id)
    {
        var cliente = await _clienteService.GetById(id);
        if (cliente == null) 
            return NotFound();
        return Ok(cliente);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]ClientePostDto clienteDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        
        var cliente = await _clienteService.Add(clienteDto);

        return Ok(cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] ClientePutDto clienteDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var updated = await _clienteService.Update(id, clienteDto);
        if (updated == null) 
            return NotFound(new { message = $"Cliente con ID {id} no encontrado." });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var deleted = await _clienteService.Delete(id);
        if (!deleted) 
            return NotFound(new { message = "Cliente no encontrado" });
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] ClientePatchDto clienteDto)
    {
        var patched = await _clienteService.Patch(id, clienteDto);
        if (patched == null) 
            return NotFound(new { message = $"Cliente con ID {id} no encontrado." });
        return NoContent();
    }
    
}
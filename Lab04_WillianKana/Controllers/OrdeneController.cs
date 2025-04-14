using Lab04_WillianKana.Application.Dtos.Ordene;
using Lab04_WillianKana.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_WillianKana.Controllers;

[Controller]
[Route("api/[controller]")]
public class OrdeneController : ControllerBase
{
    private readonly IOrdeneService _ordeneService;

    public OrdeneController(IOrdeneService ordeneService)
    {
        _ordeneService = ordeneService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var ordenes = await _ordeneService.GetAll();
        return Ok(ordenes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var ordene = await _ordeneService.GetById(id);
        if (ordene == null)
            return NotFound(new { message = $"Orden con ID {id} no encontrado." });
        return Ok(ordene);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] OrdenePostDto ordenePostDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var ordene = await _ordeneService.Add(ordenePostDto);
        return Ok(ordene);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] OrdenePutDto ordenePutDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var updated = await _ordeneService.Update(id, ordenePutDto);
        if (!updated) 
            return NotFound(new { message = $"Orden con ID {id} no encontrado." });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var deleted = await _ordeneService.Delete(id);
        if (!deleted)
            return NotFound(new { message = "Orden no encontrada" });
        return NoContent();
    }
    
}
using Lab04_WillianKana.Dtos.Detallesorden;
using Lab04_WillianKana.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_WillianKana.Controllers;

[Controller]
[Route("api/[controller]")]
public class DetallesordenController : ControllerBase
{
    private readonly IDetallesordenService _detallesordenService;

    public DetallesordenController(IDetallesordenService detallesordenService)
    {
        _detallesordenService = detallesordenService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var detallesOrdenes = await _detallesordenService.GetAll();
        return Ok(detallesOrdenes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var detalleorden = await _detallesordenService.GetById(id);
        if (detalleorden == null)
            return NotFound(new { message = $"Detalle de orden con ID {id} no encontrado." });
        return Ok(detalleorden);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] DetallesordenPostDto detalleordenDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var detalleorden = await _detallesordenService.Add(detalleordenDto);
        return Ok(detalleorden);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] DetallesordenPutDto detalleordenDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var updated = await _detallesordenService.Update(id, detalleordenDto);
        if (!updated) 
            return NotFound(new { message = $"Detalle de Orden con ID {id} no encontrado." });
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var deleted = await _detallesordenService.Delete(id);
        if (!deleted)
            return NotFound(new { message = "Detalle de Orden no encontrada" });
        return NoContent();
    }
    
}
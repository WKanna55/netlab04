using Lab04_WillianKana.Application.Dtos.Pago;
using Lab04_WillianKana.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_WillianKana.Controllers;

[Controller]
[Route("api/[controller]")]
public class PagoController : ControllerBase
{
    private readonly IPagoService _pagoService;

    public PagoController(IPagoService pagoService)
    {
        _pagoService = pagoService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pagos = await _pagoService.GetAll();
        return Ok(pagos);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var pago = await _pagoService.GetById(id);
        if (pago == null)
            return NotFound(new { message = $"Pago con ID {id} no encontrado." });
        return Ok(pago);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PagoPostDto pagoDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var pago = await _pagoService.Add(pagoDto);
        return Ok(pago);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] PagoPutDto pagoDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var updated = await _pagoService.Update(id, pagoDto);
        if (!updated) 
            return NotFound(new { message = $"Pago con ID {id} no encontrado." });
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var deleted = await _pagoService.Delete(id);
        if (!deleted)
            return NotFound(new { message = "Pago no encontrado" });
        return NoContent();
    }
    
}
using Lab04_WillianKana.Dtos.Producto;
using Lab04_WillianKana.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_WillianKana.Controllers;

[Controller]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductoController(IProductoService productoService)
    {
        _productoService = productoService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productos = await _productoService.GetAll();
        return Ok(productos);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var producto = await _productoService.GetById(id);
        if (producto == null)
            return NotFound(new { message = $"Detalle de orden con ID {id} no encontrado." });
        return Ok(producto);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductoPostDto productoDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var producto = await _productoService.Add(productoDto);
        return Ok(producto);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] ProductoPutDto productoDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var updated = await _productoService.Update(id, productoDto);
        if (!updated) 
            return NotFound(new { message = $"Producto con ID {id} no encontrado." });
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var deleted = await _productoService.Delete(id);
        if (!deleted)
            return NotFound(new { message = "Producto no encontrado" });
        return NoContent();
    }
    
}
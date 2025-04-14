using Lab04_WillianKana.Application.Dtos.Categoria;
using Lab04_WillianKana.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_WillianKana.Controllers;

[Controller]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categorias = await _categoriaService.GetAll();
        return Ok(categorias);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var categoria = await _categoriaService.GetById(id);
        if (categoria == null)
            return NotFound(new { message = $"Categoria con ID {id} no encontrada." });
        return Ok(categoria);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CategoriaPostDto categoriaDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var categoria = await _categoriaService.Add(categoriaDto);
        return Ok(categoria);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] CategoriaPutDto categoriaDto)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);
        var updated = await _categoriaService.Update(id, categoriaDto);
        if (!updated) 
            return NotFound(new { message = $"Categoria con ID {id} no encontrada." });
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var deleted = await _categoriaService.Delete(id);
        if (!deleted)
            return NotFound(new { message = "Categoria no encontrada" });
        return NoContent();
    }
    
}
using Lab04_WillianKana.Domain.Entities;
using Lab04_WillianKana.Domain.Interfaces;
using Lab04_WillianKana.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab04_WillianKana.Infrastructure.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    
    private readonly ApplicationDbContext _context;

    public CategoriaRepository(ApplicationDbContext _context) : base(_context)
    {
        this._context = _context;
    }
    
    public async Task<IEnumerable<Categoria>> GetAllWithRealtions()
    {
        return await _context.Categorias.Include(c => c.Productos).ToListAsync();
    }
    
    public async Task<Categoria> GetByIdWithRealtions(int id)
    {
        var categoria = await _context.Categorias
            .Include(c => c.Productos).FirstOrDefaultAsync(c => c.Categoriaid == id);
        return categoria!;
    }
    
}
using Lab04_WillianKana.Data;
using Lab04_WillianKana.Entities;
using Lab04_WillianKana.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lab04_WillianKana.Repositories;

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
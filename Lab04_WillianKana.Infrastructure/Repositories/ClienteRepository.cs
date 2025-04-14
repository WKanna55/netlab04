using Lab04_WillianKana.Domain.Entities;
using Lab04_WillianKana.Domain.Interfaces;
using Lab04_WillianKana.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab04_WillianKana.Infrastructure.Repositories;

public class ClienteRepository : Repository<Cliente>, IClienteRepository
{
    private readonly ApplicationDbContext _context;

    public ClienteRepository(ApplicationDbContext _context) : base(_context)
    {
        this._context = _context;
    }

    public async Task<IEnumerable<Cliente>> GetAllWithRealtions()
    {
        return await _context.Clientes.Include(c => c.Ordenes).ToListAsync();
    }

    public async Task<Cliente> GetByIdWithRealtions(int id)
    {
        var cliente = await _context.Clientes
            .Include(c => c.Ordenes).FirstOrDefaultAsync(c => c.Clienteid == id);
        return cliente!;
    }
    
}
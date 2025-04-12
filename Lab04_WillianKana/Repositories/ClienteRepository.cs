using Lab04_WillianKana.Data;
using Lab04_WillianKana.Entities;
using Lab04_WillianKana.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lab04_WillianKana.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly ApplicationDbContext _context;

    public ClienteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente?> GetById(int id) => await _context.Set<Cliente>().FindAsync(id);

    public async Task<IEnumerable<Cliente>> GetAll() => await _context.Set<Cliente>().ToListAsync();

    public async Task Add(Cliente cliente) => await _context.Set<Cliente>().AddAsync(cliente);

    public Task Update(Cliente cliente)
    {
        _context.Set<Cliente>().Update(cliente);
        return Task.CompletedTask;
    }

    public async Task Delete(int id)
    {
        var cliente = await _context.Set<Cliente>().FindAsync(id);
        if (cliente != null)
        {
            _context.Set<Cliente>().Remove(cliente);
        }
    }
    
}
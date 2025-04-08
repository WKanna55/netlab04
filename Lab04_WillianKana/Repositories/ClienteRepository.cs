using Lab04_WillianKana.Data;
using Lab04_WillianKana.Entities;
using Lab04_WillianKana.Interfaces;

namespace Lab04_WillianKana.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly ApplicationDbContext _context;

    public ClienteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Cliente GetById(int id)
    {
        return _context.Set<Cliente>().Find(id);
    }

    public IEnumerable<Cliente> GetAll()
    {
        return _context.Set<Cliente>().ToList();
    }

    public void Add(Cliente cliente)
    {
        _context.Set<Cliente>().Add(cliente);
    }

    public void Update(Cliente cliente)
    {
        _context.Set<Cliente>().Update(cliente);
    }

    public void Delete(int id)
    {
        var cliente = _context.Set<Cliente>().Find(id);
        if (cliente != null)
        {
            _context.Set<Cliente>().Remove(cliente);
        }
    }
    
}
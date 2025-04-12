using Lab04_WillianKana.Data;
using Lab04_WillianKana.Interfaces.Repositories;

namespace Lab04_WillianKana.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IClienteRepository Clientes { get; }

    public UnitOfWork(ApplicationDbContext context, IClienteRepository clienteRepository)
    {
        _context = context;
        Clientes = clienteRepository;
    }

    public async Task<int> SaveChanges()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    
}
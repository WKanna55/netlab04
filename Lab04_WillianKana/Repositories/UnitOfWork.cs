using Lab04_WillianKana.Data;
using Lab04_WillianKana.Interfaces;

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

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    
}
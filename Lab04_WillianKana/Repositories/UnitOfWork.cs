using Lab04_WillianKana.Data;
using Lab04_WillianKana.Interfaces.Repositories;

namespace Lab04_WillianKana.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly Dictionary<Type, object> _repositories = new(); // Repositorio generico
    public IClienteRepository Clientes { get; }
    public ICategoriaRepository Categorias { get; }

    public UnitOfWork(ApplicationDbContext context, IClienteRepository clienteRepository
        , ICategoriaRepository categoriaRepository)
    {
        _context = context;
        Clientes = clienteRepository;
        Categorias = categoriaRepository;
    }

    /*
     * Inicializar el repositorio con una entidad cualquiera(generico)
     */
    public IRepository<T> Repository<T>() where T : class
    {
        var type = typeof(T);
        if (!_repositories.ContainsKey(type))
        {
            var repositoryInstance = new Repository<T>(_context);
            _repositories.Add(type, repositoryInstance);
        }
        return (IRepository<T>)_repositories[type];
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
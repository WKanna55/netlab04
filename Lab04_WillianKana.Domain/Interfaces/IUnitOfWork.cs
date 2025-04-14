namespace Lab04_WillianKana.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IClienteRepository Clientes { get; }
    ICategoriaRepository Categorias { get; }
    
    IRepository<T> Repository<T>() where T : class;
    Task<int> SaveChanges();
}
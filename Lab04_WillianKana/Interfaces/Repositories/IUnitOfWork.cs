namespace Lab04_WillianKana.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    IClienteRepository Clientes { get; }
    
    IRepository<T> Repository<T>() where T : class;
    Task<int> SaveChanges();
}
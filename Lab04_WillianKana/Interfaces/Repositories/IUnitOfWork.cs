namespace Lab04_WillianKana.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    IClienteRepository Clientes { get; }
    Task<int> SaveChanges();
}
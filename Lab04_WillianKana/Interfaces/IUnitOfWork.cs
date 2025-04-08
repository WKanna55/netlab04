namespace Lab04_WillianKana.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IClienteRepository Clientes { get; }
    int SaveChanges();
}
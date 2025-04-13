using Lab04_WillianKana.Entities;

namespace Lab04_WillianKana.Interfaces.Repositories;

public interface IClienteRepository : IRepository<Cliente>
{
    Task<IEnumerable<Cliente>> GetAllWithRealtions();
    Task<Cliente> GetByIdWithRealtions(int id);
}
using Lab04_WillianKana.Domain.Entities;

namespace Lab04_WillianKana.Domain.Interfaces;

public interface IClienteRepository : IRepository<Cliente>
{
    Task<IEnumerable<Cliente>> GetAllWithRealtions();
    Task<Cliente> GetByIdWithRealtions(int id);
}
using Lab04_WillianKana.Entities;

namespace Lab04_WillianKana.Interfaces.Repositories;

public interface IClienteRepository
{
    Task<Cliente?> GetById(int id);
    Task<IEnumerable<Cliente>> GetAll();
    Task Add(Cliente cliente);
    Task Update(Cliente cliente);
    Task Delete(int id);
}
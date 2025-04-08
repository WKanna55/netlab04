using Lab04_WillianKana.Entities;

namespace Lab04_WillianKana.Interfaces;

public interface IClienteRepository
{
    Cliente GetById(int id);
    IEnumerable<Cliente> GetAll();
    void Add(Cliente cliente);
    void Update(Cliente cliente);
    void Delete(int id);
}
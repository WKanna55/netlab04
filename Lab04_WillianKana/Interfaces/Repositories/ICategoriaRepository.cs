using Lab04_WillianKana.Entities;

namespace Lab04_WillianKana.Interfaces.Repositories;

public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> GetAllWithRealtions();
    Task<Categoria> GetByIdWithRealtions(int id);
}
using Lab04_WillianKana.Domain.Entities;

namespace Lab04_WillianKana.Domain.Interfaces;

public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> GetAllWithRealtions();
    Task<Categoria> GetByIdWithRealtions(int id);
}
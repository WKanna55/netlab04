using Lab04_WillianKana.Dtos.Categoria;
using Lab04_WillianKana.Entities;

namespace Lab04_WillianKana.Interfaces.Services;

public interface ICategoriaService : IServiceBase<Categoria, CategoriaGetDto, CategoriaPostDto, CategoriaPutDto>
{
    
}
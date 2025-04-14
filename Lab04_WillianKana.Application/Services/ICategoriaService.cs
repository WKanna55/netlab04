using Lab04_WillianKana.Application.Dtos.Categoria;
using Lab04_WillianKana.Domain.Entities;

namespace Lab04_WillianKana.Application.Services;

public interface ICategoriaService 
    : IServiceBase<Categoria, CategoriaGetDto, CategoriaPostDto, CategoriaPutDto>
{
    
}
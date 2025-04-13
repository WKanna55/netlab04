using Lab04_WillianKana.Dtos.Categoria;
using Lab04_WillianKana.Dtos.Producto;
using Lab04_WillianKana.Entities;
using Lab04_WillianKana.Interfaces.Repositories;
using Lab04_WillianKana.Interfaces.Services;

namespace Lab04_WillianKana.Services;

public class CategoriaService 
    : ServiceBase<Categoria, CategoriaGetDto, CategoriaPostDto, CategoriaPutDto>, ICategoriaService
{
    public CategoriaService(IUnitOfWork unitOfWork) : base(unitOfWork) {}


    public override Categoria MapToEntity(CategoriaPostDto dto)
    {
        return new Categoria
        {
            Nombre = dto.Nombre
        };
    }

    public override CategoriaGetDto MapToGetDto(Categoria entity)
    {
        return new CategoriaGetDto
        {
            Categoriaid = entity.Categoriaid,
            Nombre = entity.Nombre,
            Productos = entity.Productos.Select(p => new ProductoGetDto
            {
                Productoid = p.Productoid,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                Stock = p.Stock,
                Categoriaid = p.Categoriaid
            }).ToList()
        };
    }

    public override void MapUpdate(Categoria entity, CategoriaPutDto dto)
    {
        entity.Nombre = dto.Nombre;
    }

    public async override Task<IEnumerable<CategoriaGetDto>> GetAll()
    {
        var categorias = await _unitOfWork.Categorias.GetAllWithRealtions();
        return categorias.Select(MapToGetDto);
    }

    public async override Task<CategoriaGetDto?> GetById(int id)
    {
        var categoria = await _unitOfWork.Categorias.GetByIdWithRealtions(id);
        return categoria == null ? default : MapToGetDto(categoria);
    }
}
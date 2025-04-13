namespace Lab04_WillianKana.Interfaces.Services;

public interface IServiceBase<TEntity, TGetDto, TPostDto, TPutDto>
{
    Task<IEnumerable<TGetDto>> GetAll();
    Task<TGetDto?> GetById(int id);
    Task<TGetDto> Add(TPostDto dto);
    Task<bool> Update(int id, TPutDto dto);
    Task<bool> Delete(int id);
}
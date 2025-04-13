using Lab04_WillianKana.Dtos.Ordene;
using Lab04_WillianKana.Entities;
using Lab04_WillianKana.Interfaces.Repositories;
using Lab04_WillianKana.Interfaces.Services;

namespace Lab04_WillianKana.Services;

public class OrdeneService : IOrdeneService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdeneService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<OrdeneGetDto>> GetAll()
    {
        var ordenes = await _unitOfWork.Repository<Ordene>().GetAll();
        var ordenesDto = ordenes.Select(o => new OrdeneGetDto
        {
            Ordenid = o.Ordenid,
            Clienteid = o.Clienteid,
            Fechaorden = o.Fechaorden,
            Total = o.Total,
        });
        return ordenesDto;
    }

    public async Task<OrdeneGetDto> GetById(int id)
    {
        var ordene = await _unitOfWork.Repository<Ordene>().GetById(id);
        if (ordene == null) 
            return null;
        var ordeneDto = new OrdeneGetDto
        {
            Ordenid = ordene.Ordenid,
            Clienteid = ordene.Clienteid,
            Fechaorden = ordene.Fechaorden,
            Total = ordene.Total
        };
        return ordeneDto;
    }

    public async Task<Ordene> Add(OrdenePostDto ordenePostDto)
    {
        var ordene = new Ordene
        {
            Clienteid = ordenePostDto.Clienteid,
            Fechaorden = ordenePostDto.Fechaorden.HasValue
                ? DateTime.SpecifyKind(ordenePostDto.Fechaorden.Value, DateTimeKind.Unspecified)
                : null,
            Total = ordenePostDto.Total
        };

        await _unitOfWork.Repository<Ordene>().Add(ordene);
        await _unitOfWork.SaveChanges();
        return ordene;
    }

    public async Task<bool> Update(int id, OrdenePutDto ordenePutDto)
    {
        var ordene = await _unitOfWork.Repository<Ordene>().GetById(id);
        if (ordene == null) 
            return false;
        ordene.Clienteid = ordenePutDto.Clienteid;
        ordene.Fechaorden = ordenePutDto.Fechaorden.HasValue
            ? DateTime.SpecifyKind(ordenePutDto.Fechaorden.Value, DateTimeKind.Unspecified)
            : null;
        ordene.Total = ordenePutDto.Total;
        await _unitOfWork.Repository<Ordene>().Update(ordene);
        await _unitOfWork.SaveChanges();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var deleted = await _unitOfWork.Repository<Ordene>().Delete(id);
        if (!deleted) 
            return false;
        await _unitOfWork.SaveChanges();
        return true;
    }
}
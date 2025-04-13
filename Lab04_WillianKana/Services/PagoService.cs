using Lab04_WillianKana.Dtos.Pago;
using Lab04_WillianKana.Entities;
using Lab04_WillianKana.Interfaces.Repositories;
using Lab04_WillianKana.Interfaces.Services;
using Lab04_WillianKana.Repositories;

namespace Lab04_WillianKana.Services;

public class PagoService : IPagoService
{
    private readonly IUnitOfWork _unitOfWork;

    public PagoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<PagoGetDto>> GetAll()
    {
        var pagos = await _unitOfWork.Repository<Pago>().GetAll();
        var pagosDto = pagos.Select(p => new PagoGetDto
        {
            Pagoid = p.Pagoid,
            Ordenid = p.Ordenid,
            Monto = p.Monto,
            Fechapago = p.Fechapago,
            Metodopago = p.Metodopago
        });
        return pagosDto;
    }

    public async Task<PagoGetDto> GetById(int id)
    {
        var pago = await _unitOfWork.Repository<Pago>().GetById(id);
        if (pago == null)
            return null;
        var pagoDto = new PagoGetDto
        {
            Pagoid = pago.Pagoid,
            Ordenid = pago.Ordenid,
            Monto = pago.Monto,
            Fechapago = pago.Fechapago,
            Metodopago = pago.Metodopago
        };
        return pagoDto;
    }

    public async Task<PagoGetDto> Add(PagoPostDto pagoDto)
    {
        var pago = new Pago
        {
            Ordenid = pagoDto.Ordenid,
            Monto = pagoDto.Monto,
            Fechapago = pagoDto.Fechapago.HasValue
                ? DateTime.SpecifyKind(pagoDto.Fechapago.Value, DateTimeKind.Unspecified)
                : null,
            Metodopago = pagoDto.Metodopago
        };

        await _unitOfWork.Repository<Pago>().Add(pago);
        await _unitOfWork.SaveChanges();

        return new PagoGetDto
        {
            Pagoid = pago.Pagoid,
            Ordenid = pago.Ordenid,
            Monto = pago.Monto,
            Fechapago = pago.Fechapago,
            Metodopago = pago.Metodopago
        };
    }

    public async Task<bool> Update(int id, PagoPutDto pagoDto)
    {
        var pago = await _unitOfWork.Repository<Pago>().GetById(id);
        if (pago == null) 
            return false;
        pago.Ordenid = pagoDto.Ordenid;
        pago.Monto = pagoDto.Monto;
        pago.Fechapago = pagoDto.Fechapago.HasValue
            ? DateTime.SpecifyKind(pagoDto.Fechapago.Value, DateTimeKind.Unspecified)
            : null;
        pago.Metodopago = pagoDto.Metodopago;
        await _unitOfWork.Repository<Pago>().Update(pago);
        await _unitOfWork.SaveChanges();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var deleted = await _unitOfWork.Repository<Pago>().Delete(id);
        if (!deleted) 
            return false;
        await _unitOfWork.SaveChanges();
        return true;
    }
    
}
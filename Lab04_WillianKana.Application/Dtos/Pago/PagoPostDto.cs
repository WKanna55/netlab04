namespace Lab04_WillianKana.Application.Dtos.Pago;

public class PagoPostDto
{
    public int? Ordenid { get; set; }

    public decimal Monto { get; set; }

    public DateTime? Fechapago { get; set; }

    public string? Metodopago { get; set; }
}
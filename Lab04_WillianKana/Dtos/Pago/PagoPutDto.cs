namespace Lab04_WillianKana.Dtos.Pago;

public class PagoPutDto
{
    public int? Ordenid { get; set; }

    public decimal Monto { get; set; }

    public DateTime? Fechapago { get; set; }

    public string? Metodopago { get; set; }
}
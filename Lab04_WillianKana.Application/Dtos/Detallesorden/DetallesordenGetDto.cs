namespace Lab04_WillianKana.Application.Dtos.Detallesorden;

public class DetallesordenGetDto
{
    public int Detalleid { get; set; }

    public int? Ordenid { get; set; }

    public int? Productoid { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }
}
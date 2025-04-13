namespace Lab04_WillianKana.Dtos.Detallesorden;

public class DetallesordenPutDto
{
    public int? Ordenid { get; set; }

    public int? Productoid { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }
}
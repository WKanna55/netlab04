using Lab04_WillianKana.Entities;

namespace Lab04_WillianKana.Dtos.Ordene;

public class OrdeneGetDto
{
    public int Ordenid { get; set; }

    public int? Clienteid { get; set; }

    public DateTime? Fechaorden { get; set; }

    public decimal Total { get; set; }

}
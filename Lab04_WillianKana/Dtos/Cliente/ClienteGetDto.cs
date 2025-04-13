using Lab04_WillianKana.Dtos.Ordene;

namespace Lab04_WillianKana.Dtos.Cliente;

public class ClienteGetDto
{
    public int Clienteid { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;
    
    public virtual ICollection<OrdeneGetDto> Ordenes { get; set; } = new List<OrdeneGetDto>();
}
namespace Lab04_WillianKana.Dtos;

public class ClienteGetDto
{
    public int Clienteid { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;
}
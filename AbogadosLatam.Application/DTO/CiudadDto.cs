namespace AbogadosLatam.Application.Features.DTO;

public class CiudadDto
{
    public int Id { get; set; }
    public int PaisId { get; set; }
    public string NombrePais { get; set; }
    public string Nombre { get; set; } = String.Empty;
}
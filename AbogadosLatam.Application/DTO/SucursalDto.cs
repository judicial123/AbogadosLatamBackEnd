namespace AbogadosLatam.Application.Features.DTO;

public class SucursalDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public decimal Latitud { get; set; }
    public decimal Longitud { get; set; }
    public bool EsPrincipal { get; set; }

    public int CiudadId { get; set; }
    public string CiudadNombre { get; set; } = string.Empty;
    
    public int EstudioId { get; set; }
    public string EstudioNombre { get; set; } = string.Empty;
}
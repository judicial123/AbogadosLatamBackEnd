namespace AbogadosLatam.Application.Features.DTO;

public class EstudioDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
    
    public SucursalDto? SucursalPrincipal { get; set; }
}
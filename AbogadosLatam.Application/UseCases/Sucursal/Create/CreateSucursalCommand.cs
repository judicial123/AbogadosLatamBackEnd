using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Sucursal;

public class CreateSucursalCommand : IRequest<int>
{
    public string Nombre { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public decimal Latitud { get; set; }
    public decimal Longitud { get; set; }
    public bool EsPrincipal { get; set; }
    public int CiudadId { get; set; }
    public int EstudioId { get; set; }
}
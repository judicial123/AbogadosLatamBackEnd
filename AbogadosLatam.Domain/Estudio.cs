using AbogadosLatam.Domain.Common;

namespace AbogadosLatam.Domain;

public class Estudio : BaseEntity
{
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
}
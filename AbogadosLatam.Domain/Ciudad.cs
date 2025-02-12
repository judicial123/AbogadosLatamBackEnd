using AbogadosLatam.Domain.Common;

namespace AbogadosLatam.Domain;

public class Ciudad : BaseEntity
{
    public int PaisId { get; set; }
    public Pais Pais { get; set; }
    public string Nombre { get; set; } = String.Empty;
}
using AbogadosLatam.Domain.Common;

namespace AbogadosLatam.Domain;

public class Abogado : BaseEntity
{
    public string Nombre { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty; // Puede contener HTML

    public string FotoUrl { get; set; } = string.Empty; // URL de la foto de perfil

    public string Whatsapp { get; set; } = string.Empty; // Número de WhatsApp

    // Relación con Estudio
    public int EstudioId { get; set; }
    public Estudio Estudio { get; set; }

    // Relación con Identity
    public string UserId { get; set; } // ID del usuario en AspNetUsers
}
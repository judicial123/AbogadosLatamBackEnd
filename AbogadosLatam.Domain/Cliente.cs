using AbogadosLatam.Domain.Common;

namespace AbogadosLatam.Domain;

public class Cliente : BaseEntity
{
    public string Telefono { get; set; } = string.Empty; // Número de teléfono del cliente

    public string DocumentoIdentidad { get; set; } = string.Empty; // Número de cédula/DNI/pasaporte

    public DateTime? FechaNacimiento { get; set; } // Fecha de nacimiento del cliente

    public string EstadoCivil { get; set; } = string.Empty; // Estado civil del cliente (Soltero, Casado, etc.)

    public string FotoUrl { get; set; } = string.Empty; // URL de la foto de perfil

    public string Notas { get; set; } = string.Empty; // Comentarios o información adicional sobre el cliente

    // Relación con Identity
    public string UserId { get; set; } // ID del usuario en AspNetUsers

    // Relación con Pais
    public int PaisId { get; set; }
    public Pais Pais { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;
using AbogadosLatam.DataSore.MSSQL.Model.Common;
using AbogadosLatam.Identity.Models;

namespace AbogadosLatam.DataSore.MSSQL.Model;

[Table("Clientes")]
public class ClienteEntity : EFEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } // Identificador único del abogado
    
    public string Telefono { get; set; } // Número de teléfono del cliente

    public string DocumentoIdentidad { get; set; } // Número de cédula/DNI/pasaporte

    public DateTime? FechaNacimiento { get; set; } // Fecha de nacimiento del cliente

    public string EstadoCivil { get; set; } // Estado civil del cliente (Soltero, Casado, etc.)

    public string FotoUrl { get; set; } // URL de la foto de perfil

    [Column(TypeName = "TEXT")]
    public string Notas { get; set; } // Comentarios o información adicional sobre el cliente

    // Relación con Identity Framework (Usuario)
    public string UserId { get; set; }
    
    // Relación con Pais
    public int PaisId { get; set; }
    
    [ForeignKey("PaisId")]
    public PaisEntity Pais { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;
using AbogadosLatam.DataSore.MSSQL.Model.Common;
using AbogadosLatam.Identity.Models;

namespace AbogadosLatam.DataSore.MSSQL.Model;

[Table("Abogados")]
public class AbogadoEntity : EFEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } // Identificador único del abogado

    [Column(TypeName = "TEXT")]
    public string Descripcion { get; set; } // Descripción en HTML

    public string FotoUrl { get; set; } // URL de la foto de perfil

    public string Whatsapp { get; set; } // Número de WhatsApp

    // Relación con Estudio
    public int EstudioId { get; set; }
    public EstudioEntity Estudio { get; set; }

    // Relación con Identity Framework (Usuario)
    public string UserId { get; set; }
}
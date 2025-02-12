using System.ComponentModel.DataAnnotations.Schema;
using AbogadosLatam.DataSore.MSSQL.Model.Common;

namespace AbogadosLatam.DataSore.MSSQL.Model;

[Table("Estudios")]
public class EstudioEntity : EFEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } // Identificador único del estudio

    public string Nombre { get; set; } // Nombre del estudio

    [Column(TypeName = "TEXT")]
    public string Descripcion { get; set; } // Descripción del estudio en HTML

    public string LogoUrl { get; set; } // URL del logo del estudio
}
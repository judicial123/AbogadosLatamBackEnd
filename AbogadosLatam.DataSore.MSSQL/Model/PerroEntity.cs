using System.ComponentModel.DataAnnotations.Schema;
using AbogadosLatam.DataSore.MSSQL.Model.Common;

namespace AbogadosLatam.DataSore.MSSQL.Model;

[Table("Perros")]
public class PerroEntity : EFEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
}

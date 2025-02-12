using System.ComponentModel.DataAnnotations.Schema;
using AbogadosLatam.DataSore.MSSQL.Model.Common;

namespace AbogadosLatam.DataSore.MSSQL.Model;

[Table("Ciudades")]
public class CiudadEntity : EFEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int PaisId { get; set; }
    public PaisEntity Pais { get; set; }
}
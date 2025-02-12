using System.ComponentModel.DataAnnotations.Schema;
using AbogadosLatam.DataSore.MSSQL.Model.Common;

namespace AbogadosLatam.DataSore.MSSQL.Model;

[Table("Paises")]
public class PaisEntity : EFEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<CiudadEntity> Ciudades { get; set; } = new List<CiudadEntity>();
}
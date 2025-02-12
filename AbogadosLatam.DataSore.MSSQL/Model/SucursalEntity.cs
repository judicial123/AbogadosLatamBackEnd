using System.ComponentModel.DataAnnotations.Schema;
using AbogadosLatam.DataSore.MSSQL.Model.Common;

namespace AbogadosLatam.DataSore.MSSQL.Model;

[Table("Sucursales")]
public class SucursalEntity : EFEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
    public decimal Latitud { get; set; }
    public decimal Longitud { get; set; }
    public bool EsPrincipal { get; set; }

    public int EstudioId { get; set; }
    public EstudioEntity Estudio { get; set; }

    public int CiudadId { get; set; }
    public CiudadEntity Ciudad { get; set; }
}
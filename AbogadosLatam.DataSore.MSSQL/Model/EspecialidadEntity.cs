using System.ComponentModel.DataAnnotations.Schema;
using AbogadosLatam.DataSore.MSSQL.Model.Common;

namespace AbogadosLatam.DataSore.MSSQL.Model;

[Table("Especialidades")]
public class EspecialidadEntity : EFEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    
    // Relación muchos a muchos con Estudio
    public ICollection<EstudioEspecialidadEntity> EstudioEspecialidades { get; set; }
}
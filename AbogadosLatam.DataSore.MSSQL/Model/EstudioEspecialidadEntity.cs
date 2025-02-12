using System.ComponentModel.DataAnnotations.Schema;
using AbogadosLatam.DataSore.MSSQL.Model.Common;

namespace AbogadosLatam.DataSore.MSSQL.Model;

[Table("EstudioEspecialidades")]
public class EstudioEspecialidadEntity : EFEntity
{
    public int EstudioId { get; set; }
    public int EspecialidadId { get; set; }

    // Relaciones de navegación
    public EstudioEntity Estudio { get; set; }
    public EspecialidadEntity Especialidad { get; set; }
}
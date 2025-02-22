using System.ComponentModel.DataAnnotations.Schema;

namespace AbogadosLatam.DataSore.MSSQL.Model.Common;

public abstract class EFEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    

    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}
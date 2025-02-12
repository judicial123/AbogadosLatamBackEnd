namespace AbogadosLatam.DataSore.MSSQL.Model.Common;

public abstract class EFEntity
{
    public int Id { get; set; }

    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}
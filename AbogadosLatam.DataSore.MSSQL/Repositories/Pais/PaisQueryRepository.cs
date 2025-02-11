namespace AbogadosLatam.DataSore.MSSQL.Repositories.Pais;

public class IPaisQueryRepository: QueryRepository<Pais>, IPaisQueryRepository
{
    public PaisCommandRepository(AbogadosLatamContext dbContext) : base(dbContext)
    {
    }
}
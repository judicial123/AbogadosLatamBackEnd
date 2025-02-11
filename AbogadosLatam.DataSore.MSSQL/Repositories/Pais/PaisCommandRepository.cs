using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;

namespace AbogadosLatam.DataSore.MSSQL.Repositories.Pais;

public class IPaisCommandRepository:CommandRepository<Domain.Pais>, Application.Contracts.IPaisCommandRepository
{
    public IPaisCommandRepository(AbogadosLatamContext dbContext) : base(dbContext)
    {
    }
}
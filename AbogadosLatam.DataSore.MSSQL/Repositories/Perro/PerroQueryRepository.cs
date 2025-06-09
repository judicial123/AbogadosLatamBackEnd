using AbogadosLatam.Application.Contracts;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model;
using AutoMapper;

namespace AbogadosLatam.DataSore.MSSQL.Repositories.Perro;

public class PerroQueryRepository : QueryRepository<Domain.Perro, PerroEntity>, IPerroQueryRepository
{
    private readonly IMapper _mapper;

    public PerroQueryRepository(AbogadosLatamContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper;
    }
}

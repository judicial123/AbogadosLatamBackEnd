using AbogadosLatam.Application.Contracts;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model;
using AutoMapper;

namespace AbogadosLatam.DataSore.MSSQL.Repositories.Perro;

public class PerroCommandRepository : CommandRepository<Domain.Perro, PerroEntity>, IPerroCommandRepository
{
    private readonly IMapper _mapper;

    public PerroCommandRepository(AbogadosLatamContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper;
    }
}

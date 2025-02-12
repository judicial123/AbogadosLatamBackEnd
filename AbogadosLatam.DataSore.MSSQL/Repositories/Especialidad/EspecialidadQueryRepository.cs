using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model;
using AbogadosLatam.Domain;
using AutoMapper;

namespace AbogadosLatam.DataSore.MSSQL.Repositories;

public class EspecialidadQueryRepository : QueryRepository<Especialidad, EspecialidadEntity>, IEspecialidadQueryRepository
{
    private readonly IMapper _mapper;

    public EspecialidadQueryRepository(AbogadosLatamContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper;
    }
}
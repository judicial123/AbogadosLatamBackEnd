using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model;
using AbogadosLatam.Domain;
using AutoMapper;

namespace AbogadosLatam.DataSore.MSSQL.Repositories;

public class EspecialidadCommandRepository : CommandRepository<Especialidad, EspecialidadEntity>, IEspecialidadCommandRepository
{
    private readonly IMapper _mapper;

    public EspecialidadCommandRepository(AbogadosLatamContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper;
    }
}
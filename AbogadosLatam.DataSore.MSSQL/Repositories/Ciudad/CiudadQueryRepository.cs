using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model;
using AbogadosLatam.Domain;
using AutoMapper;


namespace AbogadosLatam.DataSore.MSSQL.Repositories;

public class CiudadQueryRepository: QueryRepository<Ciudad, CiudadEntity>, ICiudadQueryRepository
{
    private readonly IMapper _mapper;
    public CiudadQueryRepository(AbogadosLatamContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper; // Store the mapper to use in methods specific to this repository
    }
}
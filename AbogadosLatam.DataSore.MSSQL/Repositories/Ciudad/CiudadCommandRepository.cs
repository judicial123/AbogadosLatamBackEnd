using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model;
using AbogadosLatam.Domain;
using AutoMapper;

namespace AbogadosLatam.DataSore.MSSQL.Repositories;

public class CiudadCommandRepository: CommandRepository<Ciudad, CiudadEntity>, ICiudadCommandRepository
{
    private readonly IMapper _mapper;

    public CiudadCommandRepository(AbogadosLatamContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper; // Store the mapper to use in methods specific to this repository
    }
}
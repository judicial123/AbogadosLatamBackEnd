using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model;
using AutoMapper;

namespace AbogadosLatam.DataSore.MSSQL.Repositories.Pais;

public class PaisCommandRepository:CommandRepository<Domain.Pais, PaisEntity>, Application.Contracts.IPaisCommandRepository
{
    private readonly IMapper _mapper;

    public PaisCommandRepository(AbogadosLatamContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper; // Store the mapper to use in methods specific to this repository
    }
}
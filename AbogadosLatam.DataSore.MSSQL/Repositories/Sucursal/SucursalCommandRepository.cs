using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model;
using AutoMapper;

namespace AbogadosLatam.DataSore.MSSQL.Repositories.Sucursal;

public class SucursalCommandRepository : CommandRepository<Domain.Sucursal, SucursalEntity>, ISucursalCommandRepository
{
    private readonly IMapper _mapper;

    public SucursalCommandRepository(AbogadosLatamContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper; // Store the mapper to use in methods specific to this repository
    }
}
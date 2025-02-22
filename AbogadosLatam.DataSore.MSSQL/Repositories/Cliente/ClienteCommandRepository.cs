using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model;
using AutoMapper;

namespace AbogadosLatam.DataSore.MSSQL.Repositories.Cliente;

public class ClienteCommandRepository : CommandRepository<Domain.Cliente, ClienteEntity>, IClienteCommandRepository
{
    private readonly IMapper _mapper;

    public ClienteCommandRepository(AbogadosLatamContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper;
    }
}
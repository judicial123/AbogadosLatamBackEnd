using AbogadosLatam.Application.Contracts;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model;
using AutoMapper;

namespace AbogadosLatam.DataSore.MSSQL.Repositories.Pais;

public class PaisQueryRepository : QueryRepository<Domain.Pais,PaisEntity>, IPaisQueryRepository
{
    private readonly IMapper _mapper;

    public PaisQueryRepository(AbogadosLatamContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper; // Store the mapper to use in query methods
    }

    // Aquí podrías añadir métodos de consulta que utilizan el mapeador para convertir entidades de EF a entidades de dominio
}
using AbogadosLatam.Application.Contracts;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model;
using AutoMapper;

namespace AbogadosLatam.DataSore.MSSQL.Repositories.Estudio;

public class EstudioQueryRepository : QueryRepository<Domain.Estudio, EstudioEntity>, IEstudioQueryRepository
{
    private readonly IMapper _mapper;

    public EstudioQueryRepository(AbogadosLatamContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper;
    }

    // Aquí podrías añadir métodos de consulta específicos para Estudio
}
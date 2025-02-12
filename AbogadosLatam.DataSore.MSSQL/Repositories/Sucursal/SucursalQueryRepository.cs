using AbogadosLatam.Application.Contracts;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AbogadosLatam.DataSore.MSSQL.Repositories.Sucursal;

public class SucursalQueryRepository : QueryRepository<Domain.Sucursal, SucursalEntity>, ISucursalQueryRepository
{
    private readonly IMapper _mapper;
    private readonly AbogadosLatamContext _dbContext;

    public SucursalQueryRepository(AbogadosLatamContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<List<Domain.Sucursal>> GetByEstudioIdAsync(int estudioId)
    {
        var sucursales = await _dbContext.Sucursales
            .Include(s => s.Estudio)  // Incluir la relación con Estudio
            .Include(s => s.Ciudad)   // Incluir la relación con Ciudad
            .Where(s => s.EstudioId == estudioId)
            .ToListAsync();

        return _mapper.Map<List<Domain.Sucursal>>(sucursales);
    }
}
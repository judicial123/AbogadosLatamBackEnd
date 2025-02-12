using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model.Common;
using AbogadosLatam.Domain.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AbogadosLatam.DataSore.MSSQL.Repositories;

public class QueryRepository <T, TEntity>: IQueryRepository<T> 
    where T : BaseEntity
    where TEntity : EFEntity
{
    private readonly AbogadosLatamContext _dbContext;
    private readonly IMapper _mapper;
    
    public QueryRepository(AbogadosLatamContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<T> GetByIdAsync(int id, params string[] includes)
    {
        var query = _dbContext.Set<TEntity>().AsNoTracking();

        // Incluir propiedades de navegación dinámicamente
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        // Buscar la entidad por ID
        var entity = await query.FirstOrDefaultAsync(e => e.Id == id);

        // Mapear la entidad de EF a la entidad de dominio
        return entity == null ? null : _mapper.Map<T>(entity);
    }


    public async Task<List<T>> GetAsync(params string[] includes)
    {
        var query = _dbContext.Set<TEntity>().AsNoTracking();

        // Cargar las propiedades de navegación si se especifican
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        var entities = await query.ToListAsync();
        return _mapper.Map<List<T>>(entities);
    }
}
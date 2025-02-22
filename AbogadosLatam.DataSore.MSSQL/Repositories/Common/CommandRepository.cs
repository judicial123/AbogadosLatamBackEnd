using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model.Common;
using AbogadosLatam.Domain.Common;
using AutoMapper;

namespace AbogadosLatam.DataSore.MSSQL.Repositories;

public class CommandRepository <T,TEntity>: ICommandRepository<T> 
    where T : BaseEntity  
    where TEntity : EFEntity
{
    private readonly AbogadosLatamContext _dbContext;
    private readonly IMapper _mapper;
    public CommandRepository(AbogadosLatamContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task CreateAsync(T entity)
    {
        var dbEntity = _mapper.Map<TEntity>(entity);
        
        Console.WriteLine($"Datos antes de guardar: {System.Text.Json.JsonSerializer.Serialize(dbEntity)}");

        _dbContext.Add(dbEntity);
        await _dbContext.SaveChangesAsync();

        // Asignar el ID generado a la entidad original
        _mapper.Map(dbEntity, entity);
    }

    public async Task UpdateAsync(T entity)
    {
        var dbEntity = _mapper.Map<TEntity>(entity);
        _dbContext.Update(dbEntity);
        //_dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        var dbEntity = _mapper.Map<TEntity>(entity);
        _dbContext.Remove(dbEntity);
        await _dbContext.SaveChangesAsync();
    }
}
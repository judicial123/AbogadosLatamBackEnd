using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AbogadosLatam.DataSore.MSSQL.Repositories.EstudioEspecialidad
{
    public class EstudioEspecialidadCommandRepository : CommandRepository<Domain.EstudioEspecialidad, EstudioEspecialidadEntity>, IEstudioEspecialidadCommandRepository
    {
        private readonly IMapper _mapper;
        private readonly AbogadosLatamContext _dbContext;

        public EstudioEspecialidadCommandRepository(AbogadosLatamContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AsignarEspecialidadAEstudio(int estudioId, int especialidadId)
        {
            var estudioEspecialidad = new EstudioEspecialidadEntity
            {
                EstudioId = estudioId,
                EspecialidadId = especialidadId
            };
            
            await _dbContext.EstudioEspecialidades.AddAsync(estudioEspecialidad);
            await _dbContext.SaveChangesAsync();
        }

      

   
    }
}
using AbogadosLatam.Application.Contracts;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.Domain;

namespace AbogadosLatam.DataSore.MSSQL.Repositories.EstudioEspecialidad
{
    public class EstudioEspecialidadQueryRepository : QueryRepository<Domain.EstudioEspecialidad, EstudioEspecialidadEntity>, IEstudioEspecialidadQueryRepository
    {
        private readonly IMapper _mapper;
        private readonly AbogadosLatamContext _dbContext;

        public EstudioEspecialidadQueryRepository(AbogadosLatamContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<List<Domain.Especialidad>> ObtenerEspecialidadesDeEstudio(int estudioId)
        {
            var especialidades = await _dbContext.EstudioEspecialidades
                .Where(ee => ee.EstudioId == estudioId)
                .Include(ee => ee.Especialidad)
                .Select(ee => ee.Especialidad)
                .ToListAsync();

            return _mapper.Map<List<Domain.Especialidad>>(especialidades);
        }

    }
}
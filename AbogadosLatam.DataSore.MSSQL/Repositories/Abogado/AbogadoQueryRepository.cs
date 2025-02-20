using AbogadosLatam.Application.Contracts;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbogadosLatam.DataSore.MSSQL.Repositories.Abogado
{
    public class AbogadoQueryRepository : QueryRepository<Domain.Abogado, AbogadoEntity>, IAbogadoQueryRepository
    {
        private readonly IMapper _mapper;
        private readonly AbogadosLatamContext _dbContext;

        public AbogadoQueryRepository(AbogadosLatamContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<List<Domain.Abogado>> GetByEstudioIdAsync(int estudioId)
        {
            var abogados = await _dbContext.Abogados
                .Where(a => a.EstudioId == estudioId)
                .ToListAsync();

            return _mapper.Map<List<Domain.Abogado>>(abogados);
        }
    }
}
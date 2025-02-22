using AbogadosLatam.Application.Contracts;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbogadosLatam.DataSore.MSSQL.Repositories.Cliente
{
    public class ClienteQueryRepository : QueryRepository<Domain.Cliente, ClienteEntity>, IClienteQueryRepository
    {
        private readonly IMapper _mapper;
        private readonly AbogadosLatamContext _dbContext;

        public ClienteQueryRepository(AbogadosLatamContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

       
    }
}
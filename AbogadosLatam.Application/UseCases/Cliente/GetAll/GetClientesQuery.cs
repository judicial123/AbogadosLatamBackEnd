using AbogadosLatam.Application.Features.DTO;
using MediatR;
using System.Collections.Generic;

namespace AbogadosLatam.Application.Features.UseCases.Cliente
{
    public class GetClientesQuery : IRequest<List<ClienteDto>>
    {
        // Puede incluir filtros en el futuro si es necesario, como por ejemplo por país o estado
    }
}
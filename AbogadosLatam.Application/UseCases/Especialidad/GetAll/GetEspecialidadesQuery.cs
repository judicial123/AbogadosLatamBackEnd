using AbogadosLatam.Application.Features.DTO;
using MediatR;
using System.Collections.Generic;

namespace AbogadosLatam.Application.Features.UseCases.Especialidad;

public class GetEspecialidadesQuery : IRequest<List<EspecialidadDto>>
{
    
}

// public record GetEspecialidadQuery(int Id) : IRequest<EspecialidadDto>;
using AbogadosLatam.Application.Features.DTO;
using MediatR;
using System.Collections.Generic;

namespace AbogadosLatam.Application.Features.UseCases.Especialidad.Queries;

public class GetEspecialidadesDeEstudioQuery : IRequest<List<EspecialidadDto>>
{
    public int EstudioId { get; set; }

  
}
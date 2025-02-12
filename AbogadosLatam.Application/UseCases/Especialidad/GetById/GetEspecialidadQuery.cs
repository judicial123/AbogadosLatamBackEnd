using AbogadosLatam.Application.Features.DTO;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Especialidad;

public class GetEspecialidadQuery(int id) : IRequest<EspecialidadDto>
{
    public int Id { get; set; } = id;
}
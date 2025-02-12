using AbogadosLatam.Application.Features.DTO;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Estudio;

public class GetEstudioQuery(int id) : IRequest<EstudioDto>
{
    public int Id { get; set; } = id;
}
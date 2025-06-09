using AbogadosLatam.Application.Features.DTO;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Perro;

public class GetPerroQuery(int id) : IRequest<PerroDto>
{
    public int Id { get; set; } = id;
}

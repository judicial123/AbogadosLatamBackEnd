using AbogadosLatam.Application.Features.DTO;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Pais;

public class GetPaisQuery(int id) : IRequest<PaisDto>
{
    public int Id { get; set; } = id;

    // Constructor para inicializar con el id
}
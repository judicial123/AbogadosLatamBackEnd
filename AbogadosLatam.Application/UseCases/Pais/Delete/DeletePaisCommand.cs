using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Pais;

public class DeletePaisCommand : IRequest<Unit>
{
    public int Id { get; set; }
    
}
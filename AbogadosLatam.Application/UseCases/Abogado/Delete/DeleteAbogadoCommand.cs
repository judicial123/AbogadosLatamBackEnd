using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Abogado
{
    public class DeleteAbogadoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
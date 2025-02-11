using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Ciudad
{
    public class DeleteCiudadCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
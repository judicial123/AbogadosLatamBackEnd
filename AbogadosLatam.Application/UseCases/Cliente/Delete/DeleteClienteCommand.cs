using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Cliente
{
    public class DeleteClienteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Pais;

public class CreatePaisCommand : IRequest<int>
{
    public string Nombre { get; set; } = string.Empty;
}
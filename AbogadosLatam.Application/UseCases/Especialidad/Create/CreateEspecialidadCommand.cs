using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Especialidad;

public class CreateEspecialidadCommand : IRequest<int>
{
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
}
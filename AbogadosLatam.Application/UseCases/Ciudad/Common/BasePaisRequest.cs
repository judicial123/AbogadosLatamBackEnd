using MediatR;

namespace AbogadosLatam.Application.UseCases.Ciudad.Common;

public abstract class BasePaisRequest:IRequest<int>
{
    public int PaisId { get; set; } // Relación con el país
}
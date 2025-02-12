using AbogadosLatam.Application.UseCases.Ciudad.Common;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Ciudad
{
    public class UpdateCiudadCommand : BasePaisRequest, IRequest<int>
    {
        public int Id { get; set; }  // ID de la ciudad que se actualizará
        public string? Nombre { get; set; }  // Nombre de la ciudad
        
    }
}
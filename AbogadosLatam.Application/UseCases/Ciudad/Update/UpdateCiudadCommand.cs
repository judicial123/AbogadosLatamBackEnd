using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Ciudad
{
    public class UpdateCiudadCommand : IRequest<int>
    {
        public int Id { get; set; }  // ID de la ciudad que se actualizará
        public int PaisId { get; set; }  // ID del país asociado a la ciudad
        public string? Nombre { get; set; }  // Nombre de la ciudad
        
    }
}
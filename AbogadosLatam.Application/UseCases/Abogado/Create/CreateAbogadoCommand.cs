using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Abogado
{
    public class CreateAbogadoCommand : IRequest<int>
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Whatsapp { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty; // Puede contener HTML
        public string FotoUrl { get; set; } = string.Empty; // URL de la foto
        public int EstudioId { get; set; } // Relación con el Estudio
        public string Clave { get; set; } = string.Empty; // Clave para el usuario
    }
}
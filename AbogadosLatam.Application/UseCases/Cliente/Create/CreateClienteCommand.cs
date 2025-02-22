using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Cliente
{
    public class CreateClienteCommand : IRequest<int>
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        
        public string Telefono { get; set; } = string.Empty;
        public string DocumentoIdentidad { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; }
        public string EstadoCivil { get; set; } = string.Empty;
        public string FotoUrl { get; set; } = string.Empty;
        public string Notas { get; set; } = string.Empty;
        
        public int PaisId { get; set; } // Relación con el País

        public string Email { get; set; } = string.Empty; // Email del usuario
        public string Clave { get; set; } = string.Empty; // Clave para el usuario
    }
}
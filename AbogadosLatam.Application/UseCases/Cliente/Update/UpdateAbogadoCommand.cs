using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Cliente;

public class UpdateClienteCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string FotoUrl { get; set; } = string.Empty; // URL de la foto de perfil
    public string Whatsapp { get; set; } = string.Empty; // Número de WhatsApp
    public string EstadoCivil { get; set; } = string.Empty; // Estado civil del cliente
}
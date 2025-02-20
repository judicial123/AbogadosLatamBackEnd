using AbogadosLatam.Application.Features.DTO;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Abogado;

public class UpdateAbogadoCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = string.Empty; // Puede contener HTML
    public string FotoUrl { get; set; } = string.Empty; // URL de la foto de perfil
    public string Whatsapp { get; set; } = string.Empty; // Número de WhatsApp
}
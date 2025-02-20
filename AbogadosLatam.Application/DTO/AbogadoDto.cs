namespace AbogadosLatam.Application.Features.DTO;

public class AbogadoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty; // Puede contener HTML
    public string FotoUrl { get; set; } = string.Empty; // URL de la foto de perfil
    public string Whatsapp { get; set; } = string.Empty; // Número de WhatsApp
    
    public int EstudioId { get; set; }
    public string EstudioNombre { get; set; } = string.Empty; // Para mostrar el nombre del Estudio
    
    public string UserId { get; set; } = string.Empty; // ID del usuario en Identity
    public string Email { get; set; } = string.Empty; // Para mostrar el email del usuario
    public string Password { get; set; } = string.Empty; // Clave para crear el usuario (solo en el registro)

}
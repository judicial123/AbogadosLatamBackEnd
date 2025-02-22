namespace AbogadosLatam.Application.Features.DTO;

public class ClienteDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string DocumentoIdentidad { get; set; } = string.Empty;
    public DateTime? FechaNacimiento { get; set; }
    public string EstadoCivil { get; set; } = string.Empty;
    public string FotoUrl { get; set; } = string.Empty;
    public string Notas { get; set; } = string.Empty;

    public int PaisId { get; set; }
    public string PaisNombre { get; set; } = string.Empty; // Para mostrar el nombre del país

    public string UserId { get; set; } = string.Empty; // ID del usuario en Identity
    public string Email { get; set; } = string.Empty; // Para mostrar el email del usuario
    public string Password { get; set; } = string.Empty; // Clave para crear el usuario (solo en el registro)
}
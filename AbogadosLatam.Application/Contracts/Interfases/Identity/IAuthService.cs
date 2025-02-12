using AbogadosLatam.Application.Contracts.Models.Identity;

namespace AbogadosLatam.Application.Contracts.Interfases.Identity;

public interface IAuthService
{
    
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}
using AbogadosLatam.Application.Contracts.Interfases.Identity;
using AbogadosLatam.Application.Contracts.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AbogadosLatam.WebAPI.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authenticationService;

    public AuthController(IAuthService authenticationService)
    {
        this._authenticationService = authenticationService;
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        return Ok(await _authenticationService.Login(request));
    }
    
    
    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
    {
        return Ok(await _authenticationService.Register(request));
    }
}
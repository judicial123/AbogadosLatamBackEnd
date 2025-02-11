using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AbogadosLatam.WebAPI.Controllers;

[Route("api/[controller]")]
public class CiudadController : ControllerBase
{
    private readonly IMediator _mediator;

    public CiudadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<CiudadDto>> Get()
    {
        
        var ciudades = await _mediator.Send()
    }
}
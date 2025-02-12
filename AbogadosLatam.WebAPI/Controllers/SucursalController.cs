using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Sucursal;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbogadosLatam.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SucursalController : ControllerBase
{
    private readonly IMediator _mediator;

    public SucursalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("ByEstudio/{estudioId}")]
    public async Task<ActionResult<List<SucursalDto>>> GetByEstudio(int estudioId)
    {
        var sucursales = await _mediator.Send(new GetSucursalesByEstudioQuery { EstudioId = estudioId });
        return Ok(sucursales);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SucursalDto>> Get(int id)
    {
        var sucursal = await _mediator.Send(new GetSucursalQuery(id));
        return Ok(sucursal);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateSucursalCommand sucursal)
    {
        var response = await _mediator.Send(sucursal);
        return CreatedAtAction(nameof(Get), new { id = response }, response);
    }

    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put([FromBody] UpdateSucursalCommand sucursal)
    {
        if (sucursal.Id <= 0)
        {
            return BadRequest("El ID proporcionado no es válido.");
        }

        await _mediator.Send(sucursal);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSucursalCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

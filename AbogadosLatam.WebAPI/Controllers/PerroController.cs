using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Perro;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AbogadosLatam.WebAPI.Controllers;

[Route("api/[controller]")]
public class PerroController : ControllerBase
{
    private readonly IMediator _mediator;

    public PerroController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<PerroDto>> Get()
    {
        var perros = await _mediator.Send(new GetPerrosQuery());
        return perros;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PerroDto>> Get(int id)
    {
        var perro = await _mediator.Send(new GetPerroQuery(id));
        return Ok(perro);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreatePerroCommand perro)
    {
        var response = await _mediator.Send(perro);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    [HttpPut]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put([FromBody] UpdatePerroCommand perro)
    {
        if (perro.Id <= 0)
        {
            return BadRequest("El ID proporcionado no es válido.");
        }

        await _mediator.Send(perro);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeletePerroCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

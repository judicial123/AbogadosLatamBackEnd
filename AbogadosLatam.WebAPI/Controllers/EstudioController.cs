using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Estudio;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbogadosLatam.WebAPI.Controllers;

[Route("api/[controller]")]
public class EstudioController : ControllerBase
{
    private readonly IMediator _mediator;

    public EstudioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<EstudioDto>> Get()
    {
        var estudios = await _mediator.Send(new GetEstudiosQuery());
        return estudios;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<EstudioDto>> Get(int id)
    {
        EstudioDto estudio = await _mediator.Send(new GetEstudioQuery(id));
        return Ok(estudio);
    }
    
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateEstudioCommand estudio)
    {
        var response = await _mediator.Send(estudio);
        return CreatedAtAction(nameof(Get), new { id = response });
    }
    
    [HttpPut]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put([FromBody] UpdateEstudioCommand estudio)
    {
        if (estudio.Id <= 0)
        {
            return BadRequest("El ID proporcionado no es válido.");
        }

        await _mediator.Send(estudio);

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteEstudioCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
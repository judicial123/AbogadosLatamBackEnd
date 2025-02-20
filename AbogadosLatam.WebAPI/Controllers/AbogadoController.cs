using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Abogado;
using AbogadosLatam.Application.Features.UseCases.Estudio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AbogadosLatam.WebAPI.Controllers;

[Route("api/[controller]")]
public class AbogadoController : ControllerBase
{
    private readonly IMediator _mediator;

    public AbogadoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("por-estudio/{estudioId}")]
    public async Task<List<AbogadoDto>> GetPorEstudio(int estudioId)
    {
        var abogados = await _mediator.Send(new GetAbogadosPorEstudioQuery(estudioId));
        return abogados;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<AbogadoDto>> Get(int id)
    {
        AbogadoDto abogado = await _mediator.Send(new GetAbogadoQuery(id));
        return Ok(abogado);
    }
    
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateAbogadoCommand abogado)
    {
        var response = await _mediator.Send(abogado);
        var url = Url.Action(nameof(Get), new { id = response });
        return Created(url, response);
    }
    
    [HttpPut]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put([FromBody] UpdateAbogadoCommand abogado)
    {
        if (abogado.Id <= 0)
        {
            return BadRequest("El ID proporcionado no es válido.");
        }

        await _mediator.Send(abogado);

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAbogadoCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
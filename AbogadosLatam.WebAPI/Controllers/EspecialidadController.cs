using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Especialidad;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbogadosLatam.WebAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class EspecialidadController : ControllerBase
{
    private readonly IMediator _mediator;

    public EspecialidadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<EspecialidadDto>> Get()
    {
        var especialidades = await _mediator.Send(new GetEspecialidadesQuery());
        return especialidades;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EspecialidadDto>> Get(int id)
    {
        EspecialidadDto especialidad = await _mediator.Send(new GetEspecialidadQuery(id));
        return Ok(especialidad);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateEspecialidadCommand especialidad)
    {
        var response = await _mediator.Send(especialidad);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put([FromBody] UpdateEspecialidadCommand especialidad)
    {
        if (especialidad.Id <= 0)
        {
            return BadRequest("El ID proporcionado no es válido.");
        }

        await _mediator.Send(especialidad);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteEspecialidadCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

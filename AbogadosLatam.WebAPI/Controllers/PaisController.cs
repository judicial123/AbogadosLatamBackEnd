using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Pais;
using AbogadosLatam.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbogadosLatam.WebAPI.Controllers;

//[Authorize]
[Route("api/[controller]")]
public class PaisController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaisController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<PaisDto>> Get()
    {
    //return Ok("Test endpoint is working!");
        var paises = await _mediator.Send(new GetPaisesQuery());
        return paises;
        }
    
    /*[HttpGet]
    public IActionResult Get()
    {
        return Ok("Test endpoint is working!");
    }*/
    
    [HttpGet("{id}")]
    public async Task<ActionResult<PaisDto>> Get(int id)
    {
        PaisDto pais = await _mediator.Send(new GetPaisQuery(id));
        return Ok(pais);
    }
    
    
    // POST api/<LeaveAllocationsController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreatePaisCommand  pais)
    {
        var response = await _mediator.Send(pais);
        return CreatedAtAction(nameof(Get), new { id = response });
    }
    
    [HttpPut]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put([FromBody] UpdatePaisCommand pais)
    {
        if (pais.Id <= 0)
        {
            return BadRequest("El ID proporcionado no es válido.");
        }

        await _mediator.Send(pais);

        return NoContent();
    }
    
    
    // DELETE api/<LeaveRequestsController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeletePaisCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Cliente;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AbogadosLatam.WebAPI.Controllers;

[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClienteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClienteDto>> Get(int id)
    {
        ClienteDto cliente = await _mediator.Send(new GetClienteQuery(id));
        return Ok(cliente);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateClienteCommand cliente)
    {
        var response = await _mediator.Send(cliente);
        var url = Url.Action(nameof(Get), new { id = response });
        return Created(url, response);
    }

    [HttpPut]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put([FromBody] UpdateClienteCommand cliente)
    {
        if (cliente.Id <= 0)
        {
            return BadRequest("El ID proporcionado no es válido.");
        }

        await _mediator.Send(cliente);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteClienteCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
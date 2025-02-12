using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.Features.UseCases.Ciudad;
using AbogadosLatam.Application.MappingProfiles.Exceptions;

namespace AbogadosLatam.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CiudadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ciudad
        [HttpGet]
        public async Task<List<CiudadDto>> Get()
        { 
            List<CiudadDto> ciudades = await _mediator.Send(new GetCiudadesQuery());
            return ciudades;
        }

        // GET api/ciudad/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CiudadDto>> Get(int id)
        {
            var ciudad = await _mediator.Send(new GetCiudadQuery(id));
            if (ciudad == null)
            {
                return NotFound();
            }
            return Ok(ciudad);
        }

        // POST api/ciudad
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateCiudadCommand ciudad)
        {
            int response = await _mediator.Send(ciudad);
            return CreatedAtAction(nameof(Get), new { id = response }, ciudad);
        }

        // PUT api/ciudad
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Put(UpdateCiudadCommand ciudad)
        {
            if (ciudad.Id <= 0)
            {
                return BadRequest("El ID proporcionado no es válido.");
            }

            await _mediator.Send(ciudad);
            return NoContent();
        }

        // DELETE api/ciudad/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteCiudadCommand() { Id = id };
                await _mediator.Send(command);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
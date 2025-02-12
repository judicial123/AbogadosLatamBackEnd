using AbogadosLatam.Application.Features.UseCases.EstudioEspecialidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AbogadosLatam.Application.Features.UseCases.Especialidad.Queries;

namespace AbogadosLatam.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioEspecialidadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstudioEspecialidadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Asigna una especialidad a un estudio.
        /// </summary>
        [HttpPost("asignar")]
        public async Task<IActionResult> AsignarEspecialidadAEstudio([FromBody] AsignarEspecialidadAEstudioCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { message = "Especialidad asignada correctamente." });
        }

        /// <summary>
        /// Obtiene todas las especialidades de un estudio específico.
        /// </summary>
        [HttpGet("estudio/{estudioId}")]
        public async Task<ActionResult<List<int>>> ObtenerEspecialidadesDeEstudio(int estudioId)
        {
            var query = new GetEspecialidadesDeEstudioQuery { EstudioId = estudioId };
            var especialidades = await _mediator.Send(query);
            return Ok(especialidades);
        }

        /// <summary>
        /// Elimina una especialidad de un estudio por ID de relación.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEspecialidadDeEstudio(int id)
        {
            var command = new DeleteEstudioEspecialidadCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
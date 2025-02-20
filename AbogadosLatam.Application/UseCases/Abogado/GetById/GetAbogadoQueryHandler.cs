using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Contracts.Interfases.Identity;
using AbogadosLatam.Application.Features.DTO;
using AbogadosLatam.Application.MappingProfiles.Exceptions;
using AbogadosLatam.Domain;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AbogadosLatam.Application.Features.UseCases.Estudio;

namespace AbogadosLatam.Application.Features.UseCases.Abogado
{
    public class GetAbogadoQueryHandler : IRequestHandler<GetAbogadoQuery, AbogadoDto>
    {
        private readonly IMapper _mapper;
        private readonly IAbogadoQueryRepository _abogadoRepository;
        private readonly IEstudioQueryRepository _estudioRepository;
        private readonly IAuthService _authService;

        public GetAbogadoQueryHandler(
            IMapper mapper,
            IAbogadoQueryRepository abogadoRepository,
            IEstudioQueryRepository estudioRepository,
            IAuthService authService)
        {
            _mapper = mapper;
            _abogadoRepository = abogadoRepository;
            _estudioRepository = estudioRepository;
            _authService = authService;
        }

        public async Task<AbogadoDto> Handle(GetAbogadoQuery request, CancellationToken cancellationToken)
        {
            // Obtener el abogado
            var abogado = await _abogadoRepository.GetByIdAsync(request.Id);
            if (abogado == null)
            {
                throw new NotFoundException(nameof(Abogado), request.Id);
            }

            var data = _mapper.Map<AbogadoDto>(abogado);

            // Obtener el nombre del estudio asociado
            var estudio = await _estudioRepository.GetByIdAsync(abogado.EstudioId);
            if (estudio != null)
            {
                data.EstudioNombre = estudio.Nombre;
            }

            // Obtener la información del usuario en Identity
            var authResponse = await _authService.GetUserByIdAsync(abogado.UserId);
            if (authResponse != null)
            {
                data.Nombre = authResponse.FirstName + " " + authResponse.LastName;
                data.Email = authResponse.Email;
            }

            return data;
        }
    }
}

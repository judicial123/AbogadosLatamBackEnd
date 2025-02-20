using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Contracts.Interfases.Identity;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Features.UseCases.Abogado
{
    public class GetAbogadosPorEstudioQueryHandler : IRequestHandler<GetAbogadosPorEstudioQuery, List<AbogadoDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAbogadoQueryRepository _abogadoRepository;
        private readonly IEstudioQueryRepository _estudioRepository;
        private readonly IAuthService _authService;

        public GetAbogadosPorEstudioQueryHandler(
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

        public async Task<List<AbogadoDto>> Handle(GetAbogadosPorEstudioQuery request, CancellationToken cancellationToken)
        {
            // Obtener los abogados por estudio desde la base de datos
            var abogados = await _abogadoRepository.GetByEstudioIdAsync(request.EstudioId);

            // Convertir los objetos de dominio a DTOs
            var data = _mapper.Map<List<AbogadoDto>>(abogados);

            // Obtener el nombre del estudio
            var estudio = await _estudioRepository.GetByIdAsync(request.EstudioId);
            string estudioNombre = estudio?.Nombre ?? string.Empty;

            foreach (var abogado in data)
            {
                abogado.EstudioNombre = estudioNombre;

                // Obtener la información del usuario en Identity
                var authResponse = await _authService.GetUserByIdAsync(abogado.UserId);
                if (authResponse != null)
                {
                    abogado.Nombre = $"{authResponse.FirstName} {authResponse.LastName}";
                    abogado.Email = authResponse.Email;
                }
            }

            return data;
        }
    }
}

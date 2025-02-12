using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.DTO;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AbogadosLatam.Application.Features.UseCases.Estudio
{
    public class CreateEstudioCommandHandler : IRequestHandler<CreateEstudioCommand, int>
    {
        private readonly IEstudioCommandRepository _estudioRepository;
        private readonly IMapper _mapper;

        public CreateEstudioCommandHandler(IEstudioCommandRepository estudioRepository, IMapper mapper)
        {
            _estudioRepository = estudioRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateEstudioCommand request, CancellationToken cancellationToken)
        {
            var estudio = _mapper.Map<Domain.Estudio>(request);
            await _estudioRepository.CreateAsync(estudio);
            return estudio.Id;
        }
    }
}
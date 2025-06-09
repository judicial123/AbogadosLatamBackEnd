using AbogadosLatam.Application.Contracts;
using AutoMapper;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Perro;

public class CreatePerroCommandHandler : IRequestHandler<CreatePerroCommand, int>
{
    private readonly IPerroCommandRepository _perroRepository;
    private readonly IMapper _mapper;

    public CreatePerroCommandHandler(IPerroCommandRepository perroRepository, IMapper mapper)
    {
        _perroRepository = perroRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreatePerroCommand request, CancellationToken cancellationToken)
    {
        var perro = _mapper.Map<Domain.Perro>(request);
        await _perroRepository.CreateAsync(perro);
        return perro.Id;
    }
}

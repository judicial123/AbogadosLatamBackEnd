using AbogadosLatam.Application.Contracts;
using AutoMapper;
using MediatR;

namespace AbogadosLatam.Application.Features.UseCases.Perro;

public class UpdatePerroCommandHandler : IRequestHandler<UpdatePerroCommand, Unit>
{
    private readonly IPerroCommandRepository _perroRepository;
    private readonly IPerroQueryRepository _perroQueryRepository;
    private readonly IMapper _mapper;

    public UpdatePerroCommandHandler(IPerroCommandRepository perroRepository, IPerroQueryRepository perroQueryRepository, IMapper mapper)
    {
        _perroRepository = perroRepository;
        _perroQueryRepository = perroQueryRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdatePerroCommand request, CancellationToken cancellationToken)
    {
        var existingPerro = await _perroQueryRepository.GetByIdAsync(request.Id);
        if (existingPerro == null)
        {
            throw new KeyNotFoundException($"El perro con ID {request.Id} no existe.");
        }

        existingPerro.Nombre = request.Nombre;

        await _perroRepository.UpdateAsync(existingPerro);

        return Unit.Value;
    }
}

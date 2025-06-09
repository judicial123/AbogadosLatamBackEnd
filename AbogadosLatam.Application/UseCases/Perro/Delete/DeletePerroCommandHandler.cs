using AbogadosLatam.Application.Contracts;
using MediatR;
using AbogadosLatam.Application.MappingProfiles.Exceptions;

namespace AbogadosLatam.Application.Features.UseCases.Perro;

public class DeletePerroCommandHandler : IRequestHandler<DeletePerroCommand, Unit>
{
    private readonly IPerroCommandRepository _perroRepository;
    private readonly IPerroQueryRepository _perroQueryRepository;

    public DeletePerroCommandHandler(IPerroCommandRepository perroRepository, IPerroQueryRepository perroQueryRepository)
    {
        _perroRepository = perroRepository;
        _perroQueryRepository = perroQueryRepository;
    }

    public async Task<Unit> Handle(DeletePerroCommand request, CancellationToken cancellationToken)
    {
        var perroToDelete = await _perroQueryRepository.GetByIdAsync(request.Id);

        if (perroToDelete == null)
            throw new NotFoundException(nameof(Perro), request.Id);

        await _perroRepository.DeleteAsync(perroToDelete);

        return Unit.Value;
    }
}

using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Features.UseCases.Ciudad;
using FluentValidation;

namespace AbogadosLatam.Application.UseCases.Ciudad.Common;

public class BaseCiudadCommandValidator: AbstractValidator<BasePaisRequest>
{
    private readonly IPaisQueryRepository _paisRepository;

    public BaseCiudadCommandValidator(IPaisQueryRepository paisRepository)
    {
        _paisRepository = paisRepository;


        RuleFor(p => p.PaisId)
            .GreaterThan(0)
            .MustAsync(PaisMustExist)
            .WithMessage("{PropertyName} does not exist.");
    }
    
    private async Task<bool> PaisMustExist(int id, CancellationToken arg2)
    {
        var Pais = await _paisRepository.GetByIdAsync(id);
        return Pais != null;
    }
}
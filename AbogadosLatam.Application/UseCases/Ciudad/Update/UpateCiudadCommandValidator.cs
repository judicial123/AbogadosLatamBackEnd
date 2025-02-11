using FluentValidation;
using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.Application.Features.UseCases.Ciudad;

namespace AbogadosLatam.Application.Features.UseCases.Ciudad.Validators
{
    public class UpdateCiudadCommandValidator : AbstractValidator<UpdateCiudadCommand>
    {
        private readonly IPaisRepository _paisRepository;
        private readonly ICiudadRepository _ciudadRepository;

        public UpdateCiudadCommandValidator(IPaisRepository paisRepository, ICiudadRepository ciudadRepository)
        {
            _paisRepository = paisRepository;
            _ciudadRepository = ciudadRepository;
            
            RuleFor(p => p.PaisId)
                .GreaterThan(0)
                .MustAsync(PaisMustExist)
                .WithMessage("{PropertyName} does not exist.");
            
            RuleFor(p => p.Id)
                .GreaterThan(0)
                .MustAsync(CiudadMustExist)
                .WithMessage("{PropertyName} does not exist.");
        }
        
        private async Task<bool> PaisMustExist(int id, CancellationToken cancellationToken)
        {
            var Pais = await _paisRepository.GetByIdAsync(id);
            return Pais != null;
        }
        
        private async Task<bool> CiudadMustExist(int id, CancellationToken cancellationToken)
        {
            var Ciudad = await _ciudadRepository.GetByIdAsync(id);
            return Ciudad != null;
        }
    }
}
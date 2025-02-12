using FluentValidation;
using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.Application.Features.UseCases.Ciudad;
using AbogadosLatam.Application.UseCases.Ciudad.Common;

namespace AbogadosLatam.Application.Features.UseCases.Ciudad.Validators
{
    public class UpdateCiudadCommandValidator : AbstractValidator<UpdateCiudadCommand>
    {
        private readonly IPaisQueryRepository _paisRepository;
        private readonly ICiudadQueryRepository _ciudadRepository;

        public UpdateCiudadCommandValidator(IPaisQueryRepository paisRepository, ICiudadQueryRepository ciudadRepository)
        {
            _paisRepository = paisRepository;
            _ciudadRepository = ciudadRepository;
            
            Include(new BaseCiudadCommandValidator(_paisRepository));
            
            RuleFor(p => p.Id)
                .GreaterThan(0)
                .MustAsync(CiudadMustExist)
                .WithMessage("{PropertyName} does not exist.");
        }
        
     
        
        private async Task<bool> CiudadMustExist(int id, CancellationToken cancellationToken)
        {
            var Ciudad = await _ciudadRepository.GetByIdAsync(id);
            return Ciudad != null;
        }
    }
}
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.Application.Features.UseCases.Ciudad;
using AbogadosLatam.Application.Features.UseCases.Pais;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateCiudadCommandValidator : AbstractValidator<CreateCiudadCommand>
    {
        private readonly IPaisRepository _paisRepository;

        public CreateCiudadCommandValidator(IPaisRepository paisRepository)
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
}
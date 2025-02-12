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
using AbogadosLatam.Application.UseCases.Ciudad.Common;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateCiudadCommandValidator : AbstractValidator<CreateCiudadCommand>
    {
        private readonly IPaisQueryRepository _paisRepository;

        public CreateCiudadCommandValidator(IPaisQueryRepository paisRepository)
        {
            _paisRepository = paisRepository;


           Include(new BaseCiudadCommandValidator(_paisRepository));
        }

       
    }
}
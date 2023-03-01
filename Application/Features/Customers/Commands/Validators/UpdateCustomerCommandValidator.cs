using Application.DTOS;
using Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customers.Commands.Validators
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerDto>
    {
        private readonly ICustomerRepository repo;
        public UpdateCustomerCommandValidator(ICustomerRepository repo)
        {
            this.repo = repo;

            RuleFor(c => c.Name).NotEmpty().WithMessage("Debes ingresar un nombre válido");

            RuleFor(c => c.Email).Cascade(CascadeMode.Stop)
                .EmailAddress().WithMessage("El email no es válido")
                .Must((string email) =>
                { return !repo.Get().Where(c => c.Email == email).Any(); })
                .WithMessage("El email ingresado ya existe").When(c => c.Email != null);
        } 
    }
}
